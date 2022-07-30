using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public class Request
    {

        #region Scalar properties

        public int RequestID { get; set; }

        public int UserID { get; set; }

        public int TrainnerID { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "O status do pedido é obrigatório.")]
        public RequestStatus Status { get; set; }

        [Required(ErrorMessage = "A hora do pedido é obrigatória.")]
        [DataType(DataType.Time)]
        public TimeSpan RequestHour { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [StringLength(254, ErrorMessage = "A mensagem não pode exceder 254 caracteres.")]
        [MaxLength(254)]
        public string Message { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? MessageAt { get; set; }

        #endregion

        #region Navigation properties

        public virtual User User { get; set; }

        public virtual Trainner Trainner { get; set; }

        #endregion

    }

}
