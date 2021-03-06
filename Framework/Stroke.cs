﻿using System;

namespace Framework
{
    public class Stroke
    {
        public int FirstOperand { get; private set; }
        public int SecondOperand { get; private set; }
        public int Result {
            get
            {
                switch (Operator)
                {
                    case MathadorOperators.Addition:
                        return FirstOperand + SecondOperand;
                    case MathadorOperators.Substraction:
                        int tmp = FirstOperand - SecondOperand;
                        if(tmp < 0)
                        {
                            throw new Exception("Le résultat est inférieur à 0");
                        }
                        else
                        {
                            return tmp;
                        }
                    case MathadorOperators.Multiplication:
                        return FirstOperand * SecondOperand;
                    case MathadorOperators.Division:
                        return FirstOperand / SecondOperand;
                    default:
                        return 0;
                }
            }
        }

        public MathadorOperators Operator { get; private set; }

        public Stroke(int firstOperand, int secondOperand, char mathadorOperator)
        {
            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            try
            {
                Operator = mathadorOperator.ToOperator();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int GetPoints()
        {
            return Operator.GetPoints();
        }

        public override string ToString()
        {
            return "Coup : " +
                FirstOperand.ToString() + " " +
                Operator.ToReadableChar() + " " +
                SecondOperand.ToString() + " = " +
                Result.ToString();
        }
    }
}
