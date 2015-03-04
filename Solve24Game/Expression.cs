using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve24Game
{
    class Expression
    {
        public Expression(double number, String expression)
        {
            this.number = number;
            this.expression = expression;
        }

        public double getNumber()
        {
            return number;
        }

        public String getExpression()
        {
            return expression;
        }

        private double number;
        private String expression;
    }
}
