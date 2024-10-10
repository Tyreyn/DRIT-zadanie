using DRIT_Rekrutacja.Params;
using DRIT_Rekrutacja.Helpers;
using DRIT_Rekrutacja.Workers.Template;
using Soneta.Business;
using Soneta.Kadry;
using System;

[assembly: Worker(typeof(TemplateWorker2), typeof(Pracownicy))]
namespace DRIT_Rekrutacja.Workers.Template
{
    public class TemplateWorker2
    {
        [Context]
        public Context Cx { get; set; }

        [Context]
        public Pracownik[] pracownicy { get; set; }

        [Context]
        public FigureCalculatorParams Parametry { get; set; }

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

                            pracownikZSesja.Features["DataObliczen"] = this.Parametry.OperationsDate;
                            pracownikZSesja.Features["Wynik"] = calculations.MakeFigureCalculations<double>(
                                this.Parametry.A,
                                this.Parametry.B,
                                this.Parametry.Operator);

                            trans.CommitUI();
                        }
                    }
                    nowaSesja.Save();
                }
            }
        }
    }
}
