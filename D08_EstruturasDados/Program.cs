using System;

namespace D08_EstruturasDados
{

    internal class Program
    {

        static void Main(string[] args)
        {

            #region Variáveis

            //string nome01, nome02, nome03;

            //nome01 = "Ana";
            //nome02 = "Milena";
            //nome03 = "Amélia";

            //Console.WriteLine(nome01);
            //Console.WriteLine(nome02);
            //Console.WriteLine(nome03);

            //Console.ReadLine();
            //Console.Clear();

            #endregion

            #region VETOR 1: com dimensão inicial, declaração e atribuição

            Console.Clear();
            Utils.PrintHeader("VETOR - 1");

            // Vetor com 2 elementos

            // 1º dimensionar
            string[] curso = new string[2];

            // 2º atribuir
            curso[0] = "T-SQL";
            curso[1] = "C#";
            //curso[2] = "Será???";     // Erro!

            // 3º manipular
            //Console.WriteLine(curso[0]);
            //Console.WriteLine(curso[1]);
            //Console.WriteLine(curso[2]);

            for (int i = 0; i < curso.Length; i++)
            {
                Console.WriteLine(curso[i]);
            }

            Console.ReadLine();

            #endregion

            #region VETOR 2: com dimensão inicial, declaração e atribuição duma só vez

            Console.Clear();
            Utils.PrintHeader("VETOR - 2");

            string[] pessoa = new string[4]
            {
                "a",    // pessoa[0]
                "b",    // pessoa[1]
                "c",    // pessoa[2]
                "d"     // pessoa[3]
            };

            for (int i = 0; i < pessoa.Length; i++)
            {
                Console.WriteLine(pessoa[i]);
            }

            Console.ReadLine();

            #endregion

            #region VETOR 3: sem dimensão inicial, declaração e atribuição

            Console.Clear();
            Utils.PrintHeader("VETOR - 3");

            string[] localidades = new string[]
            {
                "Porto",        // localidade[0]
                "Guimarães",    // localidade[1]
                "Braga",        // localidade[2]
                "Gaia"          // localidade[3]
            };

            string[] paises = new string[] { "Portugal", "Itália", "Brasil" };

            int[] valores = new int[] { 1, 2, 3 };

            DateTime[] dataFatura = new DateTime[]
            {
                new DateTime(2022, 05, 10),
                new DateTime(2022, 05, 11),
                new DateTime(2022, 05, 12)
            };

            Console.ReadLine();

            #endregion

            #region FOREACH para listar

            Console.Clear();
            Utils.PrintHeader("FOREACH");

            foreach (string localidade in localidades)
            {
                Console.WriteLine(localidade);
            }

            foreach (string pais in paises)
            {
                Console.WriteLine(pais);
            }

            foreach (int valor in valores)
            {
                Console.WriteLine(valor);
            }

            foreach (DateTime item in dataFatura)
            {
                Console.WriteLine(item.ToShortDateString());
            }

            Console.ReadLine();

            #endregion

            #region MATRIZ 1: com dimensão inicial

            Console.Clear();
            Utils.PrintHeader("MATRIZES");

            // Dimensionar e atribuir duma só vez
            
            // 6 elementos: 2 linhas x 3 colunas (nome, localidade, pais)
            string[,] clientes = new string[2, 3]
            {
                { 
                    "Cliente 1",        // [0,0] nome
                    "Localidade 1",     // [0,1] localidade
                    "País 1"            // [0,2] país
                },
                { 
                    "Cliente 2",        // [0,0] nome
                    "Localidade 2",     // [1,1] localidade
                    "País 2"            // [1,2] país
                }
            };

            // Dimensionar e atribuir separadamente
            string[,] produtos = new string[3,2];

            produtos[0, 0] = "Carro";
            produtos[0, 1] = "Preto";
            produtos[1, 0] = "Rato";
            produtos[1, 1] = "Branco";
            produtos[2, 0] = "Secretária";
            produtos[2, 1] = "Castanho";

            // Dimensionar dinamicamente e atribuir duma só vez
            string[,] formacoes = new string[,]
            {
                { "Curso 1", "T-SQL"},
                { "Curso 2", "C# Foundations"},
            };

            #endregion

            #region MATRIZ 2: listar com FOREACH

            Console.Clear();
            Utils.PrintHeader("MATRIZES - listar");

            foreach (string cliente in clientes)
            {
                Console.WriteLine(cliente);
            }

            foreach (string produto in produtos)
            {
                Console.WriteLine(produto);
            }

            foreach (string formacao in formacoes)
            {
                Console.WriteLine(formacao);
            }

            #endregion

            #region MATRIZ 3: listar com FORs para simular uma tabela

            Console.Clear();
            Utils.PrintHeader("MATRIZES - listar com FORs");

            Utils.PrintSubHeader("Versão com GetUpperBound()");

            for (int i = 0; i <= clientes.GetUpperBound(0); i++)
            {

                for (int j = 0; j <= clientes.GetUpperBound(1); j++)
                {

                    Console.Write($"{clientes[i, j]}\t");

                }
                
                Console.WriteLine();

            }

            Utils.PrintSubHeader("Versão com GetLength()");

            for (int i = 0; i < clientes.GetLength(0); i++)
            {

                for (int j = 0; j < clientes.GetLength(1); j++)
                {

                    Console.Write($"{clientes[i, j]}\t");

                }
                
                Console.WriteLine();

            }

            #endregion

            Console.ReadLine();

        }

    }

}
