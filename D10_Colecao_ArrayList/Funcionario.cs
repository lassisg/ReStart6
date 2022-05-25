using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D10_Colecao_ArrayList
{

    internal class Funcionario : Pessoa     // Herança = Inheritance
    {

        #region Properties

        public string Departamento { get; set; }

        #endregion

        #region Constructors (no mínimo 2)

        // Mapear os construtores desta classe para os construtores da sua base class
        public Funcionario() : base()
        {

            // Não é mandatório. Uso apenas se quiser iniciar a propriedade
            // Se não atribuir, ficará com valor null
            Departamento = string.Empty;

        }

        public Funcionario(int id, string nome, string departamento) : base(id, nome)
        {

            Departamento = departamento;

        }

        #endregion

        #region Methods



        #endregion

    }

}
