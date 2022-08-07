using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])([ /.])(0?[1-9]|1[012])([ /.])(19|20)\d\d( 00:00:00)$", ErrorMessage = "A data deve ter o formato 'dd/mm/aaaa'. Ex.: 25/11/2022.")]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessage = "A hora do pedido é obrigatória.")]
        [DataType(DataType.Time)]
        [RegularExpression(@"^([0-1][0-9]|2[0-3]):[0-5][0-9]:00$", ErrorMessage = "A hora deve ter o formato 'hh:mm'. Ex.: 16:30.")]

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

        [DataType(DataType.DateTime)]
        public DateTime? CompletedAt { get; set; }

        #endregion

        #region Navigation properties

        public User User { get; set; }

        public Trainer Trainer { get; set; }

        #endregion

        #region Methods

        public string ToString(int trainerLength, int statusLength, int messageLength)
        {

            string trainerHeader = $"{TrainerRepository.GetTrainerById(TrainerID).Code} - {TrainerRepository.GetTrainerById(TrainerID).Name}";
            string status = Status.ToString();

            StringBuilder message = new StringBuilder();

            message.Append($"{RequestID,2} | ");
            message.Append($"{RequestDate:d} {RequestHour:hh\\:mm} | ");
            message.Append($"{trainerHeader.PadRight(trainerLength)} | ");

            if (Status == RequestStatus.Concluido)
                status = $"{status} (finalizado em {CompletedAt:dd/MM/yyyy HH:mm})";

            message.Append($"{status.PadRight(statusLength)}");

            if (messageLength > 0)
                message.Append($" |");

            if (Message != null && Message.Length > 0)
                message.Append($" {Message}");

            return message.ToString();
        }

        #endregion

    }

}
