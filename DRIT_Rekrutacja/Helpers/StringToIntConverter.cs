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
        public static int ToInt(string inputString)
        {
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
