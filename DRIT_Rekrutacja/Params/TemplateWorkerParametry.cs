using DRIT_Rekrutacja.Enums;
using Soneta.Business;
using Soneta.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRIT_Rekrutacja.Params
{
    //Aby parametry działały prawidłowo dziedziczymy po klasie ContextBase
    public class TemplateWorkerParametry : ContextBase
    {
        public double A { get; set; }

        public double B { get; set; }

        [Caption("Data obliczeń")]

        public Date DataObliczen { get; set; }

        public ArithmeticOperators Operacja { get; set; }

        public TemplateWorkerParametry(Context context) : base(context)
        {
            this.DataObliczen = Date.Today;
        }
    }
}
