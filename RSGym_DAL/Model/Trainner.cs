using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public class Trainner
    {

        #region Scalar properties

        public int TrainnerID { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "O limite de caracteres permitido é 5.", MinimumLength = 5)]
        [MaxLength(5)]
        public string Code { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O limite de caracteres permitido é 100.", MinimumLength = 3)]
        [MaxLength(100)]
        public string Name { get; set; }

        #endregion

        #region Navigation properties

        public virtual ICollection<Request> Requests { get; set; }

        #endregion

    }

}
