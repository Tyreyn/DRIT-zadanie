using DRIT_Rekrutacja.Helpers.Enums;
using System;

namespace DRIT_Rekrutacja.Helpers
{

    /// <summary>
    /// Class responsible for calculations.
    /// </summary>
    public class CalculationsClass
    {

        /// <summary>
        /// Make simple calculations.
        /// </summary>
        /// <typeparam name="T">
        /// Input type variable.
        /// </typeparam>
        /// <param name="inputA">
        /// Variable A.
        /// </param>
        /// <param name="inputB">
        /// Variable B.
        /// </param>
        /// <param name="arithmeticOperator">
        /// Arithemtic operator.
        /// </param>
        /// <returns>
        /// Result of operation.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// Throw exception when dividing by zero.
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// Throw exception when input operator is not implemented yet.
        /// </exception>
        public double MakeCalculations<T>(T inputA, T inputB, ArithmeticOperatorsEnums arithmeticOperator)
        {
            dynamic A = inputA;
            dynamic B = inputB;
            if(typeof(T) == typeof(string))
            {
                A = StringToIntConverter.ToInt(A);
                B = StringToIntConverter.ToInt(B);
            }

            switch (arithmeticOperator)
            {
                case ArithmeticOperatorsEnums.Addition:
                    return A + B;
                case ArithmeticOperatorsEnums.Subtraction:
                    return A - B;
                case ArithmeticOperatorsEnums.Multiplication:
                    return A * B;
                case ArithmeticOperatorsEnums.Division:
                    if (B == 0)
                    {
                        throw new DivideByZeroException("Dzielenie przez zero nie jest dozwolone!");
                    }
                    return A / B;
                default:
                    throw new NotImplementedException("Operacja nie jest wspierana!");
            }
        }

        /// <summary>
        /// Make figure area calculation.
        /// </summary>
        /// <typeparam name="T">
        /// Input type variable.
        /// </typeparam>
        /// <param name="inputA">
        /// Variable A.
        /// </param>
        /// <param name="inputB">
        /// Variable B.
        /// </param>
        /// <param name="figure">
        /// Figure whose area is to be calculated.
        /// </param>
        /// <returns>
        /// Calculated figure area.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Throw exception when input operator is not implemented yet.
        /// </exception>
        public int MakeFigureCalculations<T>(T inputA, T inputB, FigureEnums figure)
        {
            dynamic A = inputA;
            dynamic B = inputB;
            if (typeof(T) == typeof(string))
            {
                A = StringToIntConverter.ToInt(A);
                B = StringToIntConverter.ToInt(B);
            }

            switch (figure)
            {
                case FigureEnums.Square:
                case FigureEnums.Rectangle:
                    return A * B;
                case FigureEnums.Triangle:
                    return (A * B)/2;
                case FigureEnums.Circle:
                    return (int)(Math.PI*A*A);
                default:
                    throw new NotImplementedException("Obliczenie pola dla tej figury nie jest wspierane!");
            }
        }
    }
}
