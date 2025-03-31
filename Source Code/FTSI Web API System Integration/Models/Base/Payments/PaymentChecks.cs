using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.Base.Payments
{
    public class PaymentChecks
    {
       
        public Guid Id { get; set; }

        public int? LineID { get; set; }

        public DateOnly? DueDate { get; set; }

        public int? CheckNum { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? CheckSum { get; set; }

        [MaxLength(30)]
        public string? BankCode { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
