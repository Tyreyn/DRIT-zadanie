using Soneta.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRIT_Rekrutacja.Enums
{
   public enum ArithmeticOperators
    {
        [Caption("+")]
        addition = '+',
        [Caption("-")]
        subtraction = '-',
        [Caption("*")]
        multiplication = '*',
        [Caption("/")]
        division = '/'
    }
}
