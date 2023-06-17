using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D11_ColecaoGenerica_List
{

    // Base class
    internal class Pessoa
    {

        #region Properties

        public int Id { get; set; }
        public string Nome { get; set; }

        #endregion

        #region Constructors (no mínimo 2)

        public Pessoa()
        {

            Id = 0;
            Nome = string.Empty;

        }

        public Pessoa(int id, string nome)
        {

            Id = id;
            Nome = nome;

        }

        #endregion

        #region Methods

        public void List()
        {

            Console.WriteLine($"Pessoa: {Id} - {Nome}");

        }

        #endregion

    }

}
