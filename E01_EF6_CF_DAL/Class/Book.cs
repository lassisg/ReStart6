using System;
using System.ComponentModel.DataAnnotations;

namespace E01_EF6_CF_DAL
{

    public class Book
    {

        #region Scalar properties

        public int BookId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Limite de 100 caracteres.")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Limite de 100 caracteres.")]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "Limite de 13 caracteres.")]
        [MaxLength(13)]
        public string ISBN { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? PublishDate { get; set; }

        [Required]
        public int PublisherId { get; set; }

        #endregion

        #region Navigation properties

        public virtual Publisher Publisher { get; set; }

        #endregion

    }

}
