using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public class User
    {

        #region Scalar properties

        public int UserID { get; set; }

        [Required(ErrorMessage = "O nome do utilizador é obrigatório.")]
        [StringLength(70, ErrorMessage = "O limite de caracteres permitido é 70.", MinimumLength = 2)]
        [MaxLength(70)]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z ']{2,70}$", ErrorMessage = "O nome de utilizador deve ter entre 2 e 70 caracteres.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "A palavra passe é obrigatória.")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "O limite de caracteres permitido é 50.", MinimumLength = 2)]
        [MaxLength(50)]
        [RegularExpression(@"^[\w.#$%&@]{2,50}$", ErrorMessage = "A palavra passe deve ter entre 2 e 50 caracteres.")]
        public string Password { get; set; }

        // Propriedade propositalmente não mapeada na base de dados.
        // Assim sempre será não logado ao iniciar a aplicação e evita a necessidade de fazer logout ao encerrar
        // A intenção é que fincione como uma variável de sessão com expiração ao sair da aplicação
        [NotMapped]
        public LoginStatus IsLoggedIn { get; set; }

#endregion

#region Navigation properties

        public virtual ICollection<Request> Requests { get; set; }

#endregion

    }

}
