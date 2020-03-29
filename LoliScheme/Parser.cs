using LoliScheme.Core;
using LoliScheme.Operations;
using LoliScheme.Operations.TypeOperations;
using LoliScheme.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoliScheme
{
    public class Parser
    {
        public static Expression<T> FromString<T>(string expression)
            where T : IAdd<T>, ISubtraction<T>, IMultiplication<T>, IDivision<T>, ITypeParser<T>, new ()
        {
            string expr = expression.Substring(1, expression.Length - 2);
            Operation operation = expr[0].GetOperationFromChar();
            if (expr.Contains('('))
            {
                var innerExpressions = expr
                    .SkipWhile(c => c != '(')
                    .Reverse()
                    .SkipWhile(c => c != ')')
                    .Reverse()
                    .Aggregate("", (acc, sym) => acc + sym)
                    .Split('(', StringSplitOptions.RemoveEmptyEntries)
                    .Where(str => !string.IsNullOrWhiteSpace(str) && !string.IsNullOrEmpty(str))
                    .Select(str => "(" + str).ToList();


                List<string> completedExpression = new List<string>();

                List<T> calculatedExpresssions = new List<T>();

                var firstArgs =
                    expr.Skip(1).TakeWhile(c => c != '(').Aggregate("", (acc, sym) => acc + sym);


                var secndArgs =
                        expr.TakeFromLastWhile(c => c != ')').Aggregate("", (acc, sym) => acc + sym);


                foreach (var arg in firstArgs.Split(' ').Where(str => !(string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))))
                {
                    calculatedExpresssions.Add(new T().Parser(arg));
                }

                for (int i = 1; i <= innerExpressions.Count; i++)
                {
                    if (!innerExpressions[i - 1].Contains(')'))
                    {
                        completedExpression.Add(innerExpressions[i - 1] + innerExpressions[i]);
                        innerExpressions.Remove(innerExpressions[i - 1]);
                    }
                    else
                    {
                        if (innerExpressions[i - 1].Last() != ')')
                        {
                            string str = innerExpressions[i - 1].TakeFromLastWhile(c => c != ')').Aggregate("", (acc, sym) => acc + sym);
                            completedExpression.Add(innerExpressions[i - 1].Substring(0, innerExpressions[i - 1].Length - str.Length));
                            if (!str.Split(' ', StringSplitOptions.RemoveEmptyEntries).Contains(""))
                            {
                                foreach (var  num in str.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                                {
                                    calculatedExpresssions.Add(new T().Parser(num));
                                }
                            }
                        }
                        else
                        {
                            completedExpression.Add(innerExpressions[i - 1]);
                        }
                    }
                }

                foreach (var innerExpression in completedExpression)
                {
                    if (innerExpression.Last() == ' ')
                        calculatedExpresssions.Add(FromString<T>(innerExpression.Substring(0, innerExpression.Length - 1)).Calculate());
                    else
                        calculatedExpresssions.Add(FromString<T>(innerExpression).Calculate());
                }

                foreach (var arg in secndArgs.Split(' ').Where(str => !(string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))))
                {
                    calculatedExpresssions.Add(new T().Parser(arg));
                }

                return CreateExpression(operation, calculatedExpresssions.ToArray());
            }
            else
            {
                T[] args = expr.Split(' ').Skip(1).Select(s => new T().Parser(s)).ToArray();
                return CreateExpression(operation, args);
            }
        }


        public static Expression<T> CreateExpression<T>(Operation operation, params T[] args)
            where T : IAdd<T>, ISubtraction<T>, IMultiplication<T>, IDivision<T>, ITypeParser<T>, new ()
        {
            if (args.Count() > 1)
            {
                var left = new Expression<T>(args[0]);
                return new Expression<T>(
                    operation,
                    left,
                    CreateExpression(operation, args.Skip(1).ToArray()));
            }
            else
                return new Expression<T>(args[0]);
        }
    }
}
