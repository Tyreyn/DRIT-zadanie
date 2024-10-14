using DRIT_Rekrutacja.Helpers.Enums;
using Soneta.Business;
using Soneta.Types;

namespace DRIT_Rekrutacja.Params
{
    public class SimpleCalculatorParams : ContextBase
    {
        /// <summary>
        /// Variable A.
        /// </summary>
        public double A { get; set; }

        /// <summary>
        /// Variable B.
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Date of calculation.
        /// </summary>
        [Caption("Data obliczeń")]
        public Date OperationDate { get; set; }

        /// <summary>
        /// Arithemtic operator.
        /// </summary>
        public ArithmeticOperatorsEnums Operator { get; set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="context">
        /// Enova context.
        /// </param>
        public SimpleCalculatorParams(Context context) : base(context)
        {
            this.OperationDate = Date.Today;
        }
    }
}
