using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public class Status
    {

        #region Scalar properties

        public int StatusID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O limite de caracteres permitido é 100.")]
        [MaxLength(100)]
        public string Title { get; set; }

        #endregion

        #region Navigation properties

        public virtual ICollection<Request> Requests { get; set; }

        #endregion

    }

}
