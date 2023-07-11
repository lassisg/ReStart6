﻿using System;
using System.ComponentModel.DataAnnotations;
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
        public DateTime RequestDate { get; set; }

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

            message.Append($"{RequestID,-2} | ");
            message.Append($"{RequestDate:d} {RequestDate:HH\\:mm} | ");
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