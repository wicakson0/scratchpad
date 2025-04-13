using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotationCalculator
{
    internal class NumberExpression : IExpression
    {
        private int number;
        public int Number { get; set; }

        public NumberExpression(int number)
        {  this.number = number; }

        public int interpret()
        {
            return number;
        }
    }
}
