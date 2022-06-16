using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_LINQ
{

    internal partial class LINQ
    {

        internal class Methods
        {

            private List<TimeSpan> listTimes = new List<TimeSpan>();

            internal void CreateTimeSpan()
            {
                // Criar uma timespan de números aleatórios entre 0 e 24 horas
                Random random = new Random();

                Utils.PrintSubHeader("TimeSpan list");
                for (int i = 0; i < 12; i++)
                {
                    TimeSpan timeSpan = new TimeSpan(random.Next(0, 24), random.Next(0, 60), random.Next(0, 60));
                    listTimes.Add(timeSpan);
                    Console.WriteLine($"{timeSpan}");
                }

            }

            internal void FindMorningValuesQuery()
            {
                // Usar FindAll() para localizar todas as timespans inferiores a 12 horas
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from time in listTimes
                                   where time.Hours < 12
                                   select time;

                WriteList(filteredList);
            }

            internal void FindMorningValuesMethod()
            {
                // Usar FindAll() para localizar todas as timespans inferiores a 12 horas
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listTimes.FindAll(t => t.Hours < 12);

                WriteList(filteredList);
            }

            internal void FindTimespanWithFiveQuery()
            {
                // Usar Exists() para verificar se alguma timespan tiver 5 na propriedade Hours
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from time in listTimes
                                   where time.Hours == 5
                                   select time;

                WriteList(filteredList);
            }

            internal void FindTimespanWithFiveMethod()
            {
                // Usar Exists() para verificar se alguma timespan tiver 5 na propriedade Hours
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listTimes.FindAll(t => listTimes.Exists(t1 => t.Hours == 5));

                WriteList(filteredList);
            }

            internal void CheckIfTimespanIsCorrectQuery()
            {
                // Usar TrueForAll() para garantir que todas as timespans estão entre 0 e 24 horas
                                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from time in listTimes
                                   where time.Hours >= 0 && time.Hours < 24
                                   select time;

                WriteList(filteredList);
            }

            internal void CheckIfTimespanIsCorrectMethod()
            {
                // Usar TrueForAll() para garantir que todas as timespans estão entre 0 e 24 horas
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listTimes.FindAll(t => listTimes.TrueForAll(t1 => t.Hours >= 0 && t.Hours < 24));

                WriteList(filteredList);
            }

            internal void ShowOnlyHoursQuery()
            {
                // Usar ConvertAll() para retornar só a parte de Hours de cada timespan
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from time in listTimes
                                   select time.Hours;

                foreach (var item in filteredList)
                {
                    Console.WriteLine(item);
                }
            }

            internal void ShowOnlyHoursMethod()
            {
                // Usar ConvertAll() para retornar só a parte de Hours de cada timespan
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listTimes.ConvertAll(t => t.Hours);

                foreach (var item in filteredList)
                {
                    Console.WriteLine(item);
                }
            }

            private void WriteList(IEnumerable<TimeSpan> filteredList)
            {
                foreach (var item in filteredList)
                {
                    Console.WriteLine(item);
                }
            }

        }
    
    }

}
