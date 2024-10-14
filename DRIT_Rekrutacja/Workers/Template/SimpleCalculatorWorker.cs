using DRIT_Rekrutacja.Params;
using DRIT_Rekrutacja.Helpers;
using DRIT_Rekrutacja.Workers.Template;
using Soneta.Business;
using Soneta.Kadry;
using System;

[assembly: Worker(typeof(SimpleCalculatorWorker), typeof(Pracownicy))]
namespace DRIT_Rekrutacja.Workers.Template
{
    public class SimpleCalculatorWorker
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
        /// Simple calculator params.
        /// </summary>
        [Context]
        public SimpleCalculatorParams SimpleCalculatorParams { get; set; }

        /// <summary>
        /// Make simple calculations action.
        /// </summary>
        [Action("Kalkulator",
           Description = "Prosty kalkulator",
           Priority = 10,
           Mode = ActionMode.ReadOnlySession,
           Icon = ActionIcon.Accept,
           Target = ActionTarget.ToolbarWithText)]

        public void SimpleCalculator()
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

                            pracownikZSesja.Features["DataObliczen"] = SimpleCalculatorParams.OperationDate;
                            pracownikZSesja.Features["Wynik"] = calculations.MakeCalculations(
                                    SimpleCalculatorParams.A,
                                    SimpleCalculatorParams.B,
                                    SimpleCalculatorParams.Operator);

                            trans.CommitUI();
                        }
                    }
                    nowaSesja.Save();
                }
            }
        }
    }
}
