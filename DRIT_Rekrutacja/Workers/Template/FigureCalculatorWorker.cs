using DRIT_Rekrutacja.Params;
using DRIT_Rekrutacja.Helpers;
using DRIT_Rekrutacja.Workers.Template;
using Soneta.Business;
using Soneta.Kadry;
using System;

[assembly: Worker(typeof(FigureCalculatorWorker), typeof(Pracownicy))]
namespace DRIT_Rekrutacja.Workers.Template
{
    public class FigureCalculatorWorker
    {
        /// <summary>
        /// Sonata context.
        /// </summary>
        [Context]
        public Context Cx { get; set; }

        /// <summary>
        /// Pracownicy list.
        /// </summary>
        [Context]
        public Pracownik[] pracownicy { get; set; }

        /// <summary>
        /// Figure calculator params.
        /// </summary>
        [Context]
        public FigureCalculatorParams FigureCalculatorParams { get; set; }


        /// <summary>
        /// Make figure area calculations action.
        /// </summary>
        [Action("Kalkulator figur",
           Description = "Prosty kalkulator figur",
           Priority = 10,

           Mode = ActionMode.ReadOnlySession,
           Icon = ActionIcon.Accept,
           Target = ActionTarget.ToolbarWithText)]
        public void SimpleFigureCalculator()
        {
            CalculationsClass calculations = new CalculationsClass();
            DebuggerSession.MarkLineAsBreakPoint();

            if (pracownicy?.Length != 0)
            {
                using (Session nowaSesja = this.Cx.Login.CreateSession(false, false, "ModyfikacjaPracownika"))
                {
                    foreach (Pracownik pracownik in pracownicy)
                    {
                        using (ITransaction trans = nowaSesja.Logout(true))
                        {
                            var pracownikZSesja = nowaSesja.Get(pracownik);
                            pracownikZSesja.Features["DataObliczen"] = this.FigureCalculatorParams.OperationDate;
                            pracownikZSesja.Features["WynikINT"] = calculations.MakeFigureCalculations(
                                    this.FigureCalculatorParams.A,
                                    this.FigureCalculatorParams.B,
                                    this.FigureCalculatorParams.Figure);

                            trans.CommitUI();
                        }
                    }
                    nowaSesja.Save();
                }
            }
        }
    }
}
