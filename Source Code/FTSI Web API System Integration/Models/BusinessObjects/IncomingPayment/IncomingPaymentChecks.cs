using FTSI_Web_API_System_Integration.Models.Base.Payments;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.IncomingPayment
{
    public class IncomingPaymentChecks : PaymentChecks
    {
        [ForeignKey("Id")]
        public IncomingPaymentHeader? IncomingPayment { get; set; }
    }
}
