using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public enum MathadorOperators
    {
        Addition = 0,
        Substraction = 1,
        Multiplication = 2,
        Division = 3
    }

    public static class OperatorsExtension
    {
        public static string ToReadableString(this MathadorOperators mathadorOperator)
        {
            switch (mathadorOperator)
            {
                case MathadorOperators.Addition:
                    return "+";
                case MathadorOperators.Substraction:
                    return "-";
                case MathadorOperators.Multiplication:
                    return "*";
                case MathadorOperators.Division:
                    return "/";
                default:
                    return mathadorOperator.ToString();
            }
        }

        public static MathadorOperators ToOperator(this string stringOperator)
        {
            switch (stringOperator)
            {
                case "+":
                    return MathadorOperators.Addition;
                case "-":
                    return MathadorOperators.Substraction;
                case "*":
                    return MathadorOperators.Multiplication;
                case "/":
                    return MathadorOperators.Division;
                default:
                    throw new FormatException();
            }
        }

        public static int GetPoints(this MathadorOperators mathadorOperator)
        {
            switch (mathadorOperator)
            {
                case MathadorOperators.Addition:
                    return 1;
                case MathadorOperators.Substraction:
                    return 2;
                case MathadorOperators.Multiplication:
                    return 1;
                case MathadorOperators.Division:
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
