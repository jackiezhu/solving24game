using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solve24Game
{
    public class Solving24
    {
        public Solving24(List<int> inputNumbers)
        {
            this.inputNumbers = inputNumbers;
        }

        public List<String> CalculateResult()
        {
            List<Expression> expressions = new List<Expression>();
            for (int i = 0; i < inputNumbers.Count; i++ )
            {
                int number = (int)inputNumbers[i];
                expressions.Add(new Expression(number * 1.0, Convert.ToString(number)));
            }
            List<String> result = new List<String>();
            dfs(result, expressions);
            return result;
        }

        private String generateExpression(Expression a, Expression b, int op) 
        {
            switch (op)
            {
                case 0 :
                    return "( " + a.getExpression() + " + " + b.getExpression() + " )";
                case 1:
                    return "( " + a.getExpression() + " - " + b.getExpression() + " )";
                case 2:
                    return "( " + a.getExpression() + " * " + b.getExpression() + " )";
                case 3:
                    return "( " + a.getExpression() + " / " + b.getExpression() + " )";
                default:
                    return "";
            }
        }

        private double calc(Expression a, Expression b, int op)
        {
            switch (op)
            {
                case 0:
                    return a.getNumber() + b.getNumber();
                case 1:
                    return a.getNumber() - b.getNumber();;
                case 2:
                    return a.getNumber() * b.getNumber();;
                case 3:
                    return a.getNumber() / b.getNumber();;
                default:
                    return -1;
            }
        }

        private void restruct(List<Expression> expressions, int i, int j, List<Expression> newList, int op)
        {
            for (int k = 0; k < expressions.Count; k++)
            {
                if (k != i && k != j)
                {
                    newList.Add((Expression)expressions[k]);
                }
            }

            String expression = generateExpression((Expression)expressions[i], (Expression)expressions[j], op);
            double result = calc((Expression)expressions[i], (Expression)expressions[j], op);
            newList.Add(new Expression(result, expression));
        }

        private void dfs(List<String> result, List<Expression> expressions)
        {
            if (expressions.Count < 1)
            {
                return;
            }

            if (expressions.Count == 1) 
            {
                Expression exp = (Expression)(expressions[0]);
                if (Math.Abs(exp.getNumber() - 24) < 1e-6)
                {
                    result.Add(exp.getExpression() + " = 24");
                }
                return;
            }

            for (int i = 0; i < expressions.Count; i++)
            {
                for (int j = i + 1; j < expressions.Count; j++)
                {
                    List<Expression> addList = new List<Expression>();
                    restruct(expressions, i, j, addList, 0);
                    dfs(result, addList);
                    List<Expression> minusList1 = new List<Expression>();
                    restruct(expressions, i, j, minusList1, 1);
                    dfs(result, minusList1);
                    List<Expression> minusList2 = new List<Expression>();
                    restruct(expressions, j, i, minusList2, 1);
                    dfs(result, minusList2);
                    List<Expression> multiList = new List<Expression>();
                    restruct(expressions, i, j, multiList, 2);
                    dfs(result, multiList);
                    if (Math.Abs(((Expression)expressions[i]).getNumber() - 0) < 1e-6)
                    {
                        List<Expression> divList1 = new List<Expression>();
                        restruct(expressions, j, i, divList1, 3);
                        dfs(result, divList1);
                    }

                    if (Math.Abs(((Expression)expressions[j]).getNumber() - 0) < 1e-6)
                    {
                        List<Expression> divList2 = new List<Expression>();
                        restruct(expressions, i, j, divList2, 3);
                        dfs(result, divList2);
                    }
                }
            }
        }

        private List<int> inputNumbers;

    }
}
