using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.Base.Payments
{
    public class PaymentCreditCard
    {
       
        public Guid Id { get; set; }

        public int? LineID { get; set; }

        public int? CreditCard { get; set; }

        [MaxLength(15)]
        public string? CreditAcct { get; set; }

        [MaxLength(64)]
        public string? CrCardNum { get; set; }

        public DateOnly CardValid { get; set; }

        [MaxLength(20)]
        public string? VoucherNum { get; set; } = "1";

        [Column(TypeName = "decimal(19,6)")]
        public decimal? CreditSum { get; set; }

        [MaxLength(100)]
        public string? CrTypeCode { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
