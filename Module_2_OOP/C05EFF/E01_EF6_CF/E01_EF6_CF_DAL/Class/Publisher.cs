using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E01_EF6_CF_DAL
{

    public class Publisher
    {

        #region Scalar properties

        public int PublisherId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Limite de 100 caracteres.")]
        [MaxLength(100)]
        public string Name { get; set; }

        #endregion

        #region Navigation properties

        public virtual List<Book> Books { get; set; }

        #endregion

    }

}
