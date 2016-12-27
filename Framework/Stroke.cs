using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Stroke
    {
        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }
        public int Result {
            get
            {
                switch (Operator)
                {
                    case MathadorOperators.Addition:
                        return FirstNumber + SecondNumber;
                    case MathadorOperators.Substraction:
                        return FirstNumber - SecondNumber;
                    case MathadorOperators.Multiplication:
                        return FirstNumber * SecondNumber;
                    case MathadorOperators.Division:
                        return FirstNumber / SecondNumber;
                    default:
                        return 0;
                }
            }
        }

        public MathadorOperators Operator { get; private set; }

        public Stroke(int firstNumber, int secondNumber, string mathadorOperator)
        {
            throw new NotImplementedException();
        }
    }
}
