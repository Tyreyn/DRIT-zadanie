﻿using DRIT_Rekrutacja.Params;
using DRIT_Rekrutacja.Helpers;
using DRIT_Rekrutacja.Workers.Template;
using Soneta.Business;
using Soneta.Kadry;
using System;
using ICSharpCode.NRefactory.CSharp;

[assembly: Worker(typeof(TemplateWorker), typeof(Pracownicy))]
namespace DRIT_Rekrutacja.Workers.Template
{
    public class TemplateWorker
    {
        [Context]
        public Context Cx { get; set; }

        [Context]
        public Pracownik[] pracownicy { get; set; }

        [Context]
        public SimpleCalculatorParams parametry { get; set; }

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
                    SimpleCalculatorParams parametry = new SimpleCalculatorParams(this.Cx);
                    foreach (Pracownik pracownik in pracownicy)
                    {
                        using (ITransaction trans = nowaSesja.Logout(true))
                        {
                            var pracownikZSesja = nowaSesja.Get(pracownik);

                            pracownikZSesja.Features["DataObliczen"] = parametry.OperationsDate;
                            pracownikZSesja.Features["Wynik"] = calculations.MakeCalculations<double, double>(
                                parametry.A,
                                parametry.B,
                                parametry.Operator);

                            trans.CommitUI();
                        }
                    }
                    nowaSesja.Save();
                }
            }
        }
    }
}
