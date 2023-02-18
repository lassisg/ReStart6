using System;
using System.Collections;
using D00_Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D10_Colecao_ArrayList
{

    internal class Program
    {

        static void Main(string[] args)
        {

            #region ArrayList: inteiros

            Utils4.PrintHeader("ArrayList: inteiros");

            // Instanciar o ArrayList
            ArrayList listaInteiros = new ArrayList();

            // Adicionar valores um a um
            listaInteiros.Add(1);
            listaInteiros.Add(2);
            listaInteiros.Add(3);
            listaInteiros.Add(4);

            // Adicionar valores usando um FOR
            for (int i = 5; i < 9; i++)
            {
                listaInteiros.Add(i);
            }

            // ArrayList não é tipada
            listaInteiros.Add("nove");

            // Listar
            // Se o ArrayList tiver vários tipos de dados, usar var
            foreach (var item in listaInteiros)
            {
                Console.WriteLine(item);
            }

            Utils4.CleanConsole();

            #endregion

            #region ArrayList: strings

            Utils4.PrintHeader("ArrayList: string");

            ArrayList listaStrings = new ArrayList()
            {
                "A",
                "B",
                "C"
            };

            Utils4.PrintArrayList(listaStrings);

            Utils4.CleanConsole();

            #endregion

            #region ArrayList: Pessosas

            Utils4.PrintHeader("ArrayList: Pessosas");

            ArrayList listaPessoas = new ArrayList();

            Pessoa pessoa01 = new Pessoa(1, "a");
            Pessoa pessoa02 = new Pessoa();

            pessoa02.Id = 2;
            pessoa02.Nome = "b";

            listaPessoas.Add(pessoa01);
            listaPessoas.Add(pessoa02);

            foreach (Pessoa p in listaPessoas)
            {
                Console.WriteLine($"Id: {p.Id} - Nome: {p.Nome}");
            }

            //Funcionario f1 = new Funcionario();

            Utils4.CleanConsole();

            #endregion

            #region ArrayList: Funcionarios

            Utils4.PrintHeader("ArrayList: Funcionarios");

            ArrayList listaFuncionarios = new ArrayList();

            Funcionario funcionario01 = new Funcionario(1, "f1", "d1");
            Funcionario funcionario02 = new Funcionario();

            funcionario02.Id = 2;
            funcionario02.Nome = "f2";

            listaFuncionarios.Add(funcionario01);
            listaFuncionarios.Add(funcionario02);

            foreach (Funcionario f in listaFuncionarios)
            {
                Console.WriteLine($"Id: {f.Id} - Nome: {f.Nome} - Departamento: {f.Departamento}");
            }

            //Funcionario f1 = new Funcionario();

            Utils4.CleanConsole();

            #endregion

        }

    }

}
