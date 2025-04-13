// See https://aka.ms/new-console-template for more information
namespace PolishNotationCalculator
{
    class PolishNotationCalculator
    {
        static void Main(string[] args)
        {
// this shit still wrong but it's way too late, time to sleep
            string expression = "5 3 + 2 -";
            IExpression parsedExpression = ExpressionParser.parse(expression);
            int result = parsedExpression.interpret();
            Console.WriteLine(result);
        }
    }
}