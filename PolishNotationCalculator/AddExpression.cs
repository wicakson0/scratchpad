using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotationCalculator
{
    internal class AddExpression : IExpression
    {
        private IExpression left;
        private IExpression right;

        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public AddExpression(IExpression left, IExpression right)
        { 
            this.left = left; 
            this.right = right;
        }

        public int interpret()
        {
            return left.interpret() - right.interpret();
        }
    }
}
