using D00_Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace D14_ColecaoGenerica_Dictionary
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Utils.SetUTF8Encoding();

            #region Dictionary

            Utils.PrintHeader("Dictionary");

            // Instanciar e atribuir imediatamente
            Dictionary<string, string> dicionarioStrings = new Dictionary<string, string>()
            {
                { "PT", "Portugal" },     // par chave / valor (key / value)
                { "BR", "Brasil" },
                { "ES", "Espanha" }
            };

            // Adicionar um
            dicionarioStrings.Add("IT", "Itália");

            Console.WriteLine("dicionarioStrings antes do ContainsKey com adição das Franças:");
            ListarDicionario(dicionarioStrings);

            // Pesquisar uma chave e se não existir, inserir uma linha
            // O ideal é usar LINQ
            if (!dicionarioStrings.ContainsKey("FR"))
            {
                dicionarioStrings.Add("FR", "França");
                dicionarioStrings.Add("FR2", "Franca");
                dicionarioStrings.Add("FR3", "Franssa");
            }

            Console.WriteLine("\ndicionarioStrings após o ContainsKey com adição das Franças:");
            ListarDicionario(dicionarioStrings);

            // Inserir um país lido na consola (no mínimo tem de ter 2 carateres) e não pode existir
            string novoPais, novaChave;
            int contagemChave;

            Console.Write("\nDigite o novo país (no mínimo 2 carateres): ");
            novoPais = Console.ReadLine();

            if (novoPais.Length < 2)
            {
                Console.WriteLine("No mínimo tem de ter 2 carateres.");
            }
            else if (dicionarioStrings.ContainsValue(novoPais))
            {
                Console.WriteLine("Este país já existe.");
            }
            else
            {
                // Gerar a nova chave: os 2 primeiros cateres do novoPais em maiúsculas
                novaChave = novoPais.Substring(0, 2).ToUpper();

                // Procurar a nova chave com LINQ (usa lambda operator =>)
                contagemChave = dicionarioStrings.Count(p => p.Key.Contains(novaChave));

                // Adicionar o novo pais
                if (contagemChave == 0)
                {
                    dicionarioStrings.Add(novaChave, novoPais);
                }
                else
                {
                    dicionarioStrings.Add($"{novaChave}{contagemChave + 1}", novoPais);
                }

                // Listar a coleção
                Console.WriteLine($"{novoPais} foi adicionado.");

            }


            // Pesquisar um valor 

            // Eliminar itens do dicionário e mostrar o item eliminado
            Console.WriteLine("\nRemoving:");
            Console.WriteLine($"Removing Espanha . . . {dicionarioStrings.Remove("ES")}");

            Console.WriteLine("\ndicionarioStrings após o Removing:");
            ListarDicionario(dicionarioStrings);

            Utils.CleanConsole();

            #endregion

        }

        static void ListarDicionario(Dictionary<string,string> listaPaises)
        {

            // Para ler o conteudo de dictionary, aceder a KeyValuePair<string,string>
            foreach (KeyValuePair<string,string> item in listaPaises)
            {

                Console.WriteLine($"Key: {item.Key} \tValor: {item.Value}");

            }

        }

    }

}
