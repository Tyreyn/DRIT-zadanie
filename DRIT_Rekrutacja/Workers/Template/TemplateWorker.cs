using DRIT_Rekrutacja.Enums;
using DRIT_Rekrutacja.Params;
using DRIT_Rekrutacja.Workers.Template;
using Soneta.Business;
using Soneta.Data.QueryDefinition;
using Soneta.EI;
using Soneta.Kadry;
using Soneta.Types;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: Worker(typeof(TemplateWorker), typeof(Pracownicy))]
namespace DRIT_Rekrutacja.Workers.Template
{
    public class TemplateWorker
    {

        //Obiekt Context jest to pudełko które przechowuje Typy danych, aktualnie załadowane w aplikacji
        //Atrybut Context pobiera z "Contextu" obiekty które aktualnie widzimy na ekranie

        [Context]
        public Context Cx { get; set; }

        [Context]
        public Pracownik[] pracownicy { get; set; }

        //Pobieramy z Contextu parametry, jeżeli nie ma w Context Parametrów mechanizm sam utworzy nowy obiekt oraz wyświetli jego formatkę
        [Context]
        public TemplateWorkerParametry Parametry { get; set; }

        //Atrybut Action - Wywołuje nam metodę która znajduje się poniżej
        [Action("Kalkulator",
           Description = "Prosty kalkulator ",
           Priority = 10,
           Mode = ActionMode.ReadOnlySession,
           Icon = ActionIcon.Accept,
           Target = ActionTarget.ToolbarWithText)]

        public void WykonajAkcje()
        {
            //Włączenie Debug, aby działał należy wygenerować DLL w trybie DEBUG
            DebuggerSession.MarkLineAsBreakPoint();

            if (pracownicy?.Length != 0)
            {
                using (Session nowaSesja = this.Cx.Login.CreateSession(false, false, "ModyfikacjaPracownika"))
                {
                    foreach (Pracownik pracownik in pracownicy)
                    {
                        //Otwieramy Transaction aby można było edytować obiekt z sesji
                        using (ITransaction trans = nowaSesja.Logout(true))
                        {
                            //Pobieramy obiekt z Nowo utworzonej sesji
                            var pracownikZSesja = nowaSesja.Get(pracownik);

                            //Features - są to pola rozszerzające obiekty w bazie danych, dzięki czemu nie jestesmy ogarniczeni to kolumn jakie zostały utworzone przez producenta
                            pracownikZSesja.Features["DataObliczen"] = this.Parametry.DataObliczen;
                            pracownikZSesja.Features["Wynik"] = this.WykonajObliczenia();

                            //Zatwierdzamy zmiany wykonane w sesji
                            trans.CommitUI();
                        }
                    }
                    //Zapisujemy zmiany
                    nowaSesja.Save();
                }
            }
        }

        private double WykonajObliczenia()
        {
            switch (this.Parametry.Operacja)
            {
                case ArithmeticOperators.addition:
                    return this.Parametry.A + this.Parametry.B;
                case ArithmeticOperators.subtraction:
                    return this.Parametry.A - this.Parametry.B;
                case ArithmeticOperators.multiplication:
                    return this.Parametry.A * this.Parametry.B;
                case ArithmeticOperators.division:
                    return this.Parametry.A / this.Parametry.B;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
