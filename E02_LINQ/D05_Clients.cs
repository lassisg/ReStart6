using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E02_LINQ
{
    internal partial class LINQ
    {

        internal class City
        {

            internal string Name { get; set; }
            internal string Country { get; set; }

        }

        internal class Client
        {

            internal string Name { get; set; }
            internal string Location { get; set; }
            internal int Age { get; set; }

        }

        internal class CityClient
        {

            private List<City> listCity;
            private List<Client> listClient;

            internal void CreateLists()
            {

                listCity = new List<City>()
                {
                    new City() { Name = "Porto", Country = "Portugal" },
                    new City() { Name = "Londres", Country = "Inglaterra" },
                    new City() { Name = "Paris", Country = "França" },
                    new City() { Name = "Madrid", Country = "Espanha" },
                    new City() { Name = "Lisboa", Country = "Portugal" }
                };

                listClient = new List<Client>()
                {
                    new Client() { Name = "Amália", Location = "Porto", Age = 35 },
                    new Client() { Name = "John", Location = "Londres", Age = 35 },
                    new Client() { Name = "Charles", Location = "Londres", Age = 53 },
                    new Client() { Name = "Lucy", Location = "Paris", Age = 21 },
                    new Client() { Name = "José", Location = "Lisboa", Age = 37 },
                    new Client() { Name = "Javi", Location = "Madrid", Age = 14 }
                };

            }

            internal void ListLondonClientsQuery()
            {
                // O nome dos clientes da cidade de Londres.
                Utils.PrintSubHeader("Query Syntax");

                // Versão com tipo da prop como classe
                //var filteredList = from client in listClient
                //                   where client.Location.Name == "Londres"
                //                   select client;

                // Versão com tipo da prop como string
                var filteredList = from client in listClient
                                   where client.Location == "Londres"
                                   select client;

                WriteList(filteredList);

            }

            internal void ListLondonClientsMethod()
            {
                // O nome dos clientes da cidade de Londres.
                Utils.PrintSubHeader("Method Syntax");

                // Versão com tipo da prop como classe
                //var filteredList = listClient.Where(c => c.Location.Name == "Londres");

                // Versão com tipo da prop como string
                var filteredList = listClient.Where(c => c.Location == "Londres");

                WriteList(filteredList);
            }

            internal void ListLisbonMadridClientsQuery()
            {
                // O nome dos clientes da cidade de Lisboa ou de Madrid.
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from client in listClient
                                   where client.Location == "Lisboa" || client.Location == "Madrid"
                                   select client;

                WriteList(filteredList);
            }

            internal void ListLisbonMadridClientsMethod()
            {
                // O nome dos clientes da cidade de Lisboa ou de Madrid.
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listClient.Where(c => c.Location == "Lisboa" || c.Location == "Madrid");

                WriteList(filteredList);
            }

            internal void ListAdultClientsQuery()
            {
                // Uma listagem com o formato “nome – idade” das pessoas com mais
                // de 18 anos e ordenada pela idade, descendentemente.
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from client in listClient
                                   where client.Age > 18
                                   orderby client.Age descending
                                   select client;

               WriteNameAge(filteredList);
            }

            internal void ListAdultClientsMethod()
            {
                // Uma listagem com o formato “nome – idade” das pessoas com mais
                // de 18 anos e ordenada pela idade, descendentemente.
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listClient.Where(c => c.Age > 18).OrderByDescending(c => c.Age);

                WriteNameAge(filteredList);
            }

            internal void ListAllClientsWithCountryQuery()
            {
                // O nome dos clientes e o país de origem.
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from client in listClient
                                   join city in listCity on client.Location equals city.Name
                                   select new
                                   {
                                       client.Name,
                                       city.Country
                                   };

                Console.WriteLine($"\n+{new string('-', 9)}+{new string('-', 12)}+");
                Console.WriteLine($"{"| Nome".PadRight(9)} | {"País".PadRight(10)} |");
                Console.WriteLine($"+{new string('-', 9)}+{new string('-', 12)}+");

                foreach (var item in filteredList)
                {
                    Console.WriteLine($"| {item.Name.PadRight(7)} | {item.Country.PadRight(10)} |");
                }

                Console.WriteLine($"+{new string('-', 9)}+{new string('-', 12)}+");

            }

            internal void ListAllClientsWithCountryMethod()
            {
                // O nome dos clientes e o país de origem.
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listClient
                    .Join(listCity, 
                          c1 => c1.Location, 
                          c2 => c2.Name, 
                          (c1, c2) => new { c1.Name, c2.Country });

                Console.WriteLine($"\n+{new string('-', 9)}+{new string('-', 12)}+");
                Console.WriteLine($"{"| Nome".PadRight(9)} | {"País".PadRight(10)} |");
                Console.WriteLine($"+{new string('-', 9)}+{new string('-', 12)}+");

                foreach (var item in filteredList)
                {
                    Console.WriteLine($"| {item.Name.PadRight(7)} | {item.Country.PadRight(10)} |");
                }

                Console.WriteLine($"+{new string('-', 9)}+{new string('-', 12)}+");

            }

            internal void ShowLondonClientCountQuery()
            {
                // O número de clientes que mora em Londres.
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from client in listClient
                                   join city in listCity on client.Location equals city.Name
                                   where city.Name == "Londres"
                                   select client;

                Console.WriteLine($"Clientes que moram em Londres: {filteredList.Count()}");
            }

            internal void ShowLondonClientCountMethod()
            {
                // O número de clientes que mora em Londres.
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listClient
                    .Join(listCity.Where(c2 => c2.Name == "Londres"),
                          c1 => c1.Location,
                          c2 => c2.Name,
                          (c1, c2) => new { c1.Name });

                Console.WriteLine($"Clientes que moram em Londres: {filteredList.Count()}");
            }

            internal void ShowLondonYoungerClientQuery()
            {
                // O cliente mais novo que mora em Londres.
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from client in listClient
                                   join city in listCity on client.Location equals city.Name
                                   where city.Name == "Londres"
                                   orderby client.Age
                                   select client;

                Console.WriteLine($"O cliente mais novo em Londres é: {filteredList.ElementAt(0).Name}");
            }

            internal void ShowLondonYoungerClientMethod()
            {
                // O cliente mais novo que mora em Londres.
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listClient
                    .Join(listCity.Where(c2 => c2.Name == "Londres"),
                          c1 => c1.Location,
                          c2 => c2.Name,
                          (c1, c2) => new { c1.Name , c1.Age})
                    .OrderBy(c3 => c3.Age);

                Console.WriteLine($"O cliente mais novo em Londres é: {filteredList.ElementAt(0).Name}");
            }

            private void WriteList(IEnumerable<Client> filteredList)
            {
                foreach (var item in filteredList)
                {
                    Console.WriteLine(item.Name);
                }
            }

            private void WriteNameAge(IEnumerable<Client> filteredList)
            {
                Console.WriteLine($"\n+{new string('-', 9)}+{new string('-', 7)}+");
                Console.WriteLine($"{"| Nome".PadRight(9)} | {"Idade".PadRight(2)} |");
                Console.WriteLine($"+{new string('-', 9)}+{new string('-', 7)}+");

                foreach (var item in filteredList)
                {
                    Console.WriteLine($"| {item.Name.PadRight(7)} | {item.Age}{"".PadRight(3)} |");
                }

                Console.WriteLine($"+{new string('-', 9)}+{new string('-', 7)}+");
            }


        }

    }

}
