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

        public Colaborador(int colaboradorID, string nome, string email)
        {
            ColaboradorID = colaboradorID;
            Nome = nome;
            Email = email;
            Localidade = "Porto";
        }

        public Colaborador(int colaboradorID, string nome, string email, string localidade)
        {
            ColaboradorID= colaboradorID;
            Nome = nome;
            Email = email;
            Localidade = localidade;
        }

        #endregion

        #region Methods



        #endregion

    }

}
