using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotationCalculator
{
    internal class ExpressionParser
    {
        private static bool isNumber(String token)
        {
            return double.TryParse(token, out _);
        }

        public static IExpression parse(String expression)
        {
            Stack<IExpression> stack = new Stack<IExpression>();
            string[] tokens = expression.Split(' ');

            foreach (string token in tokens)
            {
                if (isNumber(token))
                {
                    stack.Push(new NumberExpression(int.Parse(token)));
                }
                else
                {
                    IExpression right = stack.Pop();
                    IExpression left = stack.Pop();

                    switch (token)
                    {
                        case "+":
                            stack.Push(new AddExpression(left, right)); break;
                        case "-":
                            stack.Push(new SubstractExpression(left, right)); break;
                        default:
                            throw new ArgumentException(token);
                    }
                }
            }
            return stack.Pop();
        }
    }
}
