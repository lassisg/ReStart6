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

        internal class City
        {

            internal string Name { get; set; }
            internal string Country { get; set; }

        }

        internal class Client
        {

            internal string Name { get; set; }
            internal City Location { get; set; }
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
                    new Client() { Name = "Amália", Location = listCity.ElementAt(0), Age = 35 },
                    new Client() { Name = "John", Location = listCity.ElementAt(1), Age = 35 },
                    new Client() { Name = "Charles", Location = listCity.ElementAt(1), Age = 53 },
                    new Client() { Name = "Lucy", Location = listCity.ElementAt(2), Age = 21 },
                    new Client() { Name = "José", Location = listCity.ElementAt(4), Age = 37 },
                    new Client() { Name = "Javi", Location = listCity.ElementAt(3), Age = 14 }
                };

            }

            internal void ListLondonClientsQuery()
            {
                // O nome dos clientes da cidade de Londres.
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from client in listClient
                                   where client.Location.Name == "Londres"
                                   select client;

                WriteList(filteredList);

            }

            internal void ListLondonClientsMethod()
            {
                // O nome dos clientes da cidade de Londres.
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listClient.Where(c => c.Location.Name == "Londres");

                WriteList(filteredList);
            }

            internal void ListLisbonMadridClientsQuery()
            {
                // O nome dos clientes da cidade de Lisboa ou de Madrid.
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from client in listClient
                                   where client.Location.Name == "Lisboa" || client.Location.Name == "Madrid"
                                   select client;

                WriteList(filteredList);
            }

            internal void ListLisbonMadridClientsMethod()
            {
                // O nome dos clientes da cidade de Lisboa ou de Madrid.
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listClient.Where(c => c.Location.Name == "Lisboa" || c.Location.Name == "Madrid");

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

                WriteNameCountry(listClient);

            }

            internal void ListAllClientsWithCountryMethod()
            {
                // O nome dos clientes e o país de origem.
                Utils.PrintSubHeader("Method Syntax");

                WriteNameCountry(listClient);

            }

            internal void ShowLondonClientCountQuery()
            {
                // O número de clientes que mora em Londres.
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from client in listClient
                                   where client.Location.Name == "Londres"
                                   select client;

                Console.WriteLine($"Clientes que moram em Londres: {filteredList.Count()}");
            }

            internal void ShowLondonClientCountMethod()
            {
                // O número de clientes que mora em Londres.
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listClient.Where(c => c.Location.Name == "Londres");

                Console.WriteLine($"Clientes que moram em Londres: {filteredList.Count()}");
            }

            internal void ShowLondonYoungerClientQuery()
            {
                // O cliente mais novo que mora em Londres.
                Utils.PrintSubHeader("Query Syntax");

                var filteredList = from client in listClient
                                   where client.Location.Name == "Londres"
                                   orderby client.Age
                                   select client;

                Console.WriteLine($"O cliente mais novo em Londres é: {filteredList.ElementAt(0).Name}");
            }

            internal void ShowLondonYoungerClientMethod()
            {
                // O cliente mais novo que mora em Londres.
                Utils.PrintSubHeader("Method Syntax");

                var filteredList = listClient
                    .Where(c => c.Location.Name == "Londres")
                    .OrderBy(c => c.Age);

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

            private void WriteNameCountry(IEnumerable<Client> filteredList)
            {
                Console.WriteLine($"\n+{new string('-', 9)}+{new string('-', 12)}+");
                Console.WriteLine($"{"| Nome".PadRight(9)} | {"País".PadRight(10)} |");
                Console.WriteLine($"+{new string('-', 9)}+{new string('-', 12)}+");

                foreach (var item in filteredList)
                {
                    Console.WriteLine($"| {item.Name.PadRight(7)} | {item.Location.Country.PadRight(10)} |");
                }

                Console.WriteLine($"+{new string('-', 9)}+{new string('-', 12)}+");
            }

        }

    }

}

