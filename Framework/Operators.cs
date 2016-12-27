using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public enum MathadorOperators
    {
        Addition,
        Substraction,
        Multiplication,
        Division
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
    }
}
