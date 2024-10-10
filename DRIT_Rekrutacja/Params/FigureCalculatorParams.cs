using DRIT_Rekrutacja.Helpers.Enums;
using Soneta.Business;
using Soneta.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRIT_Rekrutacja.Params
{
    public class FigureCalculatorParams : ContextBase
    {
        public double A { get; set; }

        public double B { get; set; }

        [Caption("Data obliczeń")]

        public Date OperationsDate { get; set; }

        public FigureEnums Operator { get; set; }

        public FigureCalculatorParams(Context context) : base(context)
        {
            this.OperationsDate = Date.Today;
        }
    }
}
