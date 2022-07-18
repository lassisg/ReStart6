using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E02_EF6_CF_Migrations_Books_DAL
{

    public class Publisher
    {

        #region Scalar properties

        public int PublisherID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "100 character limit.")]
        [MaxLength(100)]
        public string Name { get; set; }

        #endregion

        #region Navigation properties

        // 1 publisher - n books
        public ICollection<Book> Book { get; set; }

        #endregion

    }

}
