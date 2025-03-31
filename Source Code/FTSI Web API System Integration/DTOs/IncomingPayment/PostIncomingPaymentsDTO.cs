using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.DTOs.IncomingPayment
{
    public class PostIncomingPaymentsDTO
    {
        [Required]
        [MaxLength(30)]
        public string? SubmitId { get; set; }

        [Required]
        public List<IncomingPaymentHeaderDTO> Data { get; set; } = [];
    }
}
