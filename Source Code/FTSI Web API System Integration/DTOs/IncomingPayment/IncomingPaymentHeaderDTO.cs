using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FTSI_Web_API_System_Integration.DTOs.IncomingPayment
{
    public class IncomingPaymentHeaderDTO
    {
        [Required]
        [MaxLength(15)]
        public string? CardCode { get; set; }

        [MaxLength(100)]
        [Required]
        public string? CardName { get; set; }

        [Required]
        public DateOnly? DocDate { get; set; }

        public string? CashAccnt { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? CashSum { get; set; }

        [MaxLength(15)]
        public string? TrsfrAcct { get; set; }

        [JsonIgnore]
        public DateOnly? TrsfrDate { get; set; }

        [MaxLength(15)]
        public string? TrsfrRef { get; set; }

        [Required]
        [Column(TypeName = "decimal(19,6)")]
        public decimal? TrsfrSum { get; set; }

        [MaxLength(30)]
        [Required]
        public string? U_RefNum { get; set; }

        [Required]
        public List<IncomingPaymentInvoicesDTO> PaymentInvoices { get; set; } = [];
        public List<IncomingPaymentChecksDTO>? PaymentChecks { get; set; } = [];
        public List<IncomingPaymentCreditCardDTO>? PaymentCreditCard { get; set; } = [];

    }
}
