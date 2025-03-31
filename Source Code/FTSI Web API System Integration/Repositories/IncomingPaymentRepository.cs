using FTSI_Web_API_System_Integration.Data;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.IncomingPayment;
using Microsoft.EntityFrameworkCore;

namespace FTSI_Web_API_System_Integration.Repositories
{
    public class IncomingPaymentRepository : IIncomingPaymentRepository
    {
        private readonly FTDBWContext _db;

        public IncomingPaymentRepository(FTDBWContext db)
        {
            _db = db;
        }

        public async Task AddAsync(IncomingPaymentHeader payment)
        {
            await _db.FTORCT.AddAsync(payment);
        }

        public async Task AddRangeAsync(List<IncomingPaymentHeader> payments)
        {
            await _db.FTORCT.AddRangeAsync(payments);
        }

        public async Task<IncomingPaymentHeader?> CheckSubmitId(string submitId)
        {
            return await _db.FTORCT.FirstOrDefaultAsync(el => el.SubmitId == submitId);
        }

        public async Task<List<IncomingPaymentHeader>?> GetInquiryAsync(string submitId)
        {
            return await _db.FTORCT.Where(x => x.SubmitId == submitId).ToListAsync();
        }

        public async Task<IncomingPaymentHeader?> GetStatusAsync(Guid id)
        {
            return await _db.FTORCT.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }


    }
}
