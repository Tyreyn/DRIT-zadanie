using DRIT_Rekrutacja.Helpers.Enums;
using System;

namespace DRIT_Rekrutacja.Helpers
{
    public class CalculationsClass
    {

        public Tout MakeCalculations<Tin, Tout>(Tin inputA, Tin inputB, ArithmeticOperatorsEnums operation)
        {
            dynamic A = inputA;
            dynamic B = inputB;
            if(typeof(Tin) == typeof(string))
            {
                A = StringToIntConverter.ToInt(A);
                B = StringToIntConverter.ToInt(B);
            }

            switch (operation)
            {
                case ArithmeticOperatorsEnums.addition:
                    return A + B;
                case ArithmeticOperatorsEnums.subtraction:
                    return A - B;
                case ArithmeticOperatorsEnums.multiplication:
                    return A * B;
                case ArithmeticOperatorsEnums.division:
                    if (B == 0)
                    {
                        throw new DivideByZeroException("Division by zero is not allowed.");
                    }
                    return A / B;
                default:
                    throw new NotImplementedException();
            }
        }

        public int MakeFigureCalculations<Tin>(Tin inputA, Tin inputB, FigureEnums figure)
        {
            dynamic A = inputA;
            dynamic B = inputB;
            if (typeof(Tin) == typeof(string))
            {
                A = StringToIntConverter.ToInt(A);
                B = StringToIntConverter.ToInt(B);
            }

            switch (figure)
            {
                case FigureEnums.square:
                case FigureEnums.rectangle:
                    return A * B;
                case FigureEnums.triangle:
                    return (A * B)/2;
                case FigureEnums.circle:
                    return Math.PI*Math.Pow(A,2);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
