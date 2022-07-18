using System.ComponentModel.DataAnnotations;

namespace E02_EF6_CF_Migrations_Books_DAL
{

    public class Book
    {

        #region Scalar properties

        public int BookID { get; set; }

        // Foreign key, without data anootation, just using code conventions
        public int PublisherID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "100 character limit.")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "9 character limit.")]
        [MaxLength(100)]
        public string ISBN { get; set; }

        #endregion

        #region Navigation properties

        // 1 book - n publishers
        public Publisher Publisher { get; set; }

        #endregion

    }

}
