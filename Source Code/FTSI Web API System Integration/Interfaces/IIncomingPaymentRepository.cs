using FTSI_Web_API_System_Integration.Models.BusinessObjects.IncomingPayment;

namespace FTSI_Web_API_System_Integration.Interfaces
{
    public interface IIncomingPaymentRepository
    {
        Task AddAsync(IncomingPaymentHeader payment);
        Task AddRangeAsync(List<IncomingPaymentHeader> headers);
        Task<IncomingPaymentHeader?> CheckSubmitId(string submitId);
        Task<List<IncomingPaymentHeader>?> GetInquiryAsync(string refnum);
        Task<IncomingPaymentHeader?> GetStatusAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}