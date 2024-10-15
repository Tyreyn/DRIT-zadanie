using Soneta.Tools;
using System;

namespace DRIT_Rekrutacja.Helpers
{
    /// <summary>
    /// String to int converter.
    /// </summary>
    public static class StringToIntConverter
    {
        /// <summary>
        /// Converts string to int.
        /// </summary>
        /// <param name="inputString">
        /// Input string.
        /// </param>
        /// <returns>
        /// Converted int.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throw exception when input string is empty.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throw exception when input is not number.
        /// </exception>
        public static int ToInt(string inputString)
        {
            if(inputString.IsNullOrEmpty()) throw new ArgumentNullException("Zmienna jest pusta");
            int result = 0;
            foreach(char number in inputString)
            {
                if (Char.IsDigit(number))
                {
                    result = (result * 10) + (number - '0');
                }
                else
                {
                    throw new ArgumentException(inputString + ": Zmienna nie jest liczbą");
                }
            }
            return result;
        }
    }
}
