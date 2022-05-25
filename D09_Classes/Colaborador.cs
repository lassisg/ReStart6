using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09_Classes
{

    internal class Colaborador
    {

        #region Fields: variáveis privadas à classe que suportam as propriedades clássicas

        private string nome;

        #endregion

        #region Properties

        // Propriedades auto-implemented
        public int ColaboradorID { get; set; }
        public string Email { get; set; }
        public string Localidade { get; set; }

        // Propriedades clássicas
        public string Nome          // usa-se o correspondente field
        { 
            get { return nome; }
            set { nome = value; }
        }

        // Expression bodied: Avançado, não utilizaremos
        // public string LastName => "Nome";

        #endregion

        #region Constructors

        public Colaborador()
        {
            ColaboradorID = 0;
            Nome = "";
            Email = "";
            Localidade = string.Empty;
        }

        #endregion

    }

}
