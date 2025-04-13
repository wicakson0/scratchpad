using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PolishNotationCalculator
{
    internal class SubstractExpression : IExpression
    {
        private IExpression left;
        private IExpression right;

        public IExpression Right { get; set; }
        public IExpression Left { get; set; }

        public SubstractExpression(IExpression left, IExpression right)
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
