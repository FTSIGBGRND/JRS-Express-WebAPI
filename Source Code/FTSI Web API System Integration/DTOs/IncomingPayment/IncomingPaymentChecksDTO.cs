using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.DTOs.IncomingPayment
{
    public class IncomingPaymentChecksDTO
    {
        [Required]
        public DateOnly? DueDate { get; set; }

        [Required]
        public int? CheckNum { get; set; }

        [Required]
        [Column(TypeName = "decimal(19,6)")]
        public decimal? CheckSum { get; set; }

        [Required]
        [MaxLength(30)]
        public string? BankCode { get; set; }

    }
}
