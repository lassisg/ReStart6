using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utils;

namespace E02_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Utils.SetUTF8Encoding();

            #region HelloWorld

            //Utils.PrintHeader("Hello World");

            //LINQ.HelloWorld.HelloWorldMethodSyntax();
            //LINQ.HelloWorld.HelloWorldQuerySyntax();

            //Utils.CleanConsole();

            #endregion

            #region GreaterThanTen

            //Utils.PrintHeader("Numbers >= 10");
            //// Listar os números superiores ou iguais a 10 duma lista com 10 números
            //// inteiros gerados aleatoriamente entre 0 e 50.

            //LINQ.GreaterOrEqualToTen greaterOrEqualToTen = new LINQ.GreaterOrEqualToTen();

            //greaterOrEqualToTen.CreateList();
            //greaterOrEqualToTen.FilterListQuery();
            //greaterOrEqualToTen.FilterListMethod();

            //Utils.CleanConsole();

            #endregion

            #region ShorterName

            //Utils.PrintHeader("Shorter names");
            //// Listar os nomes mais curtos dum array de strings.

            //LINQ.ShorterNames shorterNames = new LINQ.ShorterNames();

            //shorterNames.CreateList();
            //shorterNames.FilterListQuery();
            //shorterNames.FilterListMethod();

            //Utils.CleanConsole();

            #endregion

            #region CityClient

            LINQ.CityClient cityClient = new LINQ.CityClient();
            cityClient.CreateLists();

            Utils.PrintHeader("CityClient | Nome dos clientes da cidade de Londres.");
            cityClient.ListLondonClientsQuery();
            cityClient.ListLondonClientsMethod();

            Utils.PrintHeader("CityClient | Nome dos clientes da cidade de Lisboa ou de Madrid.", "\n", false);
            cityClient.ListLisbonMadridClientsQuery();
            cityClient.ListLisbonMadridClientsMethod();

            Utils.PrintHeader("CityClient | Listagem com o formato “nome – idade” das pessoas com\nmais de 18 anos e ordenada pela idade, descendentemente.", "\n", false);
            cityClient.ListAdultClientsQuery();
            cityClient.ListAdultClientsMethod();

            Utils.PrintHeader("CityClient | Nome dos clientes e o país de origem.", "\n", false);
            cityClient.ListAllClientsWithCountryQuery();
            cityClient.ListAllClientsWithCountryMethod();

            Utils.PrintHeader("CityClient | Número de clientes que mora em Londres.", "\n", false);
            cityClient.ShowLondonClientCountQuery();
            cityClient.ShowLondonClientCountMethod();

            Utils.PrintHeader("CityClient | Cliente mais novo que mora em Londres.", "\n", false);
            cityClient.ShowLondonYoungerClientQuery();
            cityClient.ShowLondonYoungerClientMethod();

            Utils.CleanConsole();

            #endregion
        }

    }

}
