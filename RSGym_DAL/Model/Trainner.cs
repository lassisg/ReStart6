using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public class Trainner : ITrainner
    {

        #region Scalar properties

        public int TrainnerID { get; set; }


        [Required]
        [StringLength(5, ErrorMessage = "O limite de caracteres permitido é 5.", MinimumLength = 5)]
        [MaxLength(5)]
        [RegularExpression(@"^(PT_)(\d){2}$", ErrorMessage = "O código do treinador deve ter 5 caracteres, no seguinte padrão: PT_01.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "O nome do treinador é obrigatório.")]
        [StringLength(70, ErrorMessage = "O limite de caracteres permitido é 70.", MinimumLength = 2)]
        [MaxLength(70)]
        [RegularExpression(@"^[\w][\w ']{2,70}$", ErrorMessage = "O nome do treinador deve ter entre 2 e 70 caracteres.")]
        public string Name { get; set; }

        #endregion

        #region Navigation properties

        public virtual ICollection<Request> Requests { get; set; }

        #endregion

    }

}
