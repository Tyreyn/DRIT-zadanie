using DRIT_Rekrutacja.Helpers.Enums;
using Soneta.Business;
using Soneta.Types;

namespace DRIT_Rekrutacja.Params
{
    /// <summary>
    /// Figure parameters class.
    /// </summary>
    public class FigureCalculatorParams : ContextBase
    {
        /// <summary>
        /// Variable A.
        /// </summary>
        public string A { get; set; }

        /// <summary>
        /// Variable B.
        /// </summary>
        public string B { get; set; }

        /// <summary>
        /// Date of calculation.
        /// </summary>
        [Caption("Data obliczeń")]
        public Date OperationDate { get; set; }

        /// <summary>
        /// Figure whose area is to be calculated.
        /// </summary>
        public FigureEnums Figure { get; set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="context">
        /// Enova context.
        /// </param>
        public FigureCalculatorParams(Context context) : base(context)
        {
            this.OperationDate = Date.Today;
        }
    }
}
