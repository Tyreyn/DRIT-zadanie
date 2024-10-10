using DRIT_Rekrutacja.Helpers.Enums;
using Soneta.Business;
using Soneta.Types;

namespace DRIT_Rekrutacja.Params
{
    public class SimpleCalculatorParams : ContextBase
    {
        public double A { get; set; }

        public double B { get; set; }

        [Caption("Data obliczeń")]

        public Date OperationsDate { get; set; }

        public ArithmeticOperatorsEnums Operator { get; set; }

        public SimpleCalculatorParams(Context context) : base(context)
        {
            this.OperationsDate = Date.Today;
        }
    }
}
