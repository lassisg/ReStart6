using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(100, ErrorMessage = "O limite de caracteres permitido é 100.", MinimumLength = 4)]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "A palavra passe é obrigatória.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "O limite de caracteres permitido é 100.", MinimumLength = 4)]
        [MaxLength(100)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Password { get; set; }

        #endregion

        #region Navigation properties

        public virtual ICollection<Request> Requests { get; set; }

        #endregion

    }

}
