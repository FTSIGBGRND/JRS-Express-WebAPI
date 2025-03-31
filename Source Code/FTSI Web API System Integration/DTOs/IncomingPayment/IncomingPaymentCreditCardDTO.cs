using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.DTOs.IncomingPayment
{
    public class IncomingPaymentCreditCardDTO
    {
        [Required]
        public int? LineID { get; set; }

        [Required]
        public int? CreditCard { get; set; }

        [Required]
        [MaxLength(15)]
        public string? CreditAcct { get; set; }

        [Required]
        [MaxLength(64)]
        public string? CrCardNum { get; set; }

        [Required]
        public DateOnly CardValid { get; set; }

        [Required]
        [MaxLength(20)]
        public string? VoucherNum { get; set; } = "1";

        [Required]
        [Column(TypeName = "decimal(19,6)")]
        public decimal? CreditSum { get; set; }

        [Required]
        [MaxLength(100)]
        public string? CrTypeCode { get; set; }


    }
}
