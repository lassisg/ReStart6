﻿using D00_Utils;
using System.Collections.Generic;

namespace D11_ColecaoGenerica_List
{

    internal class Program
    {

        static void Main(string[] args)
        {

            Utils4.SetUTF8Encoding();

            #region Criar 1 pessoa com o 2º constructor e listar

            Utils4.PrintHeader("Criar 1 pessoa com o 2º constructor e listar");

            Pessoa p1 = new Pessoa(1, "Leandro");
            Pessoa p2 = new Pessoa(2, "Leonardo");

            p1.List();
            p2.List();

            Utils4.CleanConsole();

            #endregion

            #region List<Pessoa>

            Utils4.PrintHeader("List<Pessoa>");

            List<Pessoa> listaPessoas = new List<Pessoa>();

            listaPessoas.Add(p1);
            listaPessoas.Add(p2);

            // Listar
            foreach (Pessoa item in listaPessoas)
            {
                item.List();
            }

            Utils4.CleanConsole();

            #endregion

            #region List<int>

            Utils4.PrintHeader("List<int>");

            List<int> listaInteiros = new List<int>();

            listaInteiros.Add(1);
            listaInteiros.Add(2);
            // listaInteiros.Add('a');      // Erro!!! Não aceita char pq deve ser int
            // listaInteiros.Add(1.5);      // Erro!!! Não aceita double pq deve ser int

            Utils4.CleanConsole();

            #endregion

        }

    }

}
