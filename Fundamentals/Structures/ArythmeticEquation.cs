using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class ArythmeticEquation
    {
        /// write a program to solve an arithmetic expressions with numbers and +-* and no parenthesis
        /// 
        
        public static double Calculate3(string equation)
        {
            string lastValue = "";
            Stack<double> values = new Stack<double>();
            char lastOperation = ' ';

            for (int i = 0; i <= equation.Length; i++)
            {
                if (equation.Length > i && char.IsDigit(equation[i]))
                {
                    lastValue += equation[i];
                    continue;
                }

                double lastDouble = double.Parse(lastValue);
                lastValue = "";

                if (lastOperation == '-')
                {
                    values.Push(lastDouble * -1);
                }

                if (lastOperation == '+')
                {
                    values.Push(lastDouble);
                }

                if (lastOperation == '*')
                {
                    values.Push(lastDouble * values.Pop());
                }

                if(lastOperation == ' ')
                {
                    values.Push(lastDouble);
                }

                if (equation.Length == i)
                {
                    return values.Sum(v => v);
                }

                lastOperation = equation[i];
            }

            throw new Exception();
        }

    }
}
