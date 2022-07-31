using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGym_DAL
{

    public class Request : IRequest
    {

        #region Scalar properties

        public int RequestID { get; set; }

        public int UserID { get; set; }

        public int TrainerID { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        [Column(TypeName = "date")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "A hora do pedido é obrigatória.")]
        [DataType(DataType.Time)]
        
        public TimeSpan RequestHour { get; set; }

        [Required(ErrorMessage = "O status do pedido é obrigatório.")]
        public RequestStatus Status { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [StringLength(254, ErrorMessage = "A mensagem não pode exceder 254 caracteres.")]
        [MaxLength(254)]
        public string Message { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? MessageAt { get; set; }

        #endregion

        #region Navigation properties

        public virtual User User { get; set; }

        public virtual Trainer Trainer { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            string trainer = $"{RequestID:d} - Data: {RequestDate:d} {RequestHour.ToString(@"hh\:mm")} | PT: {TrainerRepository.GetTrainerById(TrainerID).Name}";
            return trainer;
        }

        #endregion

    }

}
