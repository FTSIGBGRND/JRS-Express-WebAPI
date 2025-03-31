using FTSI_Web_API_System_Integration.Data;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using Microsoft.EntityFrameworkCore;

namespace FTSI_Web_API_System_Integration.Repositories
{
    public class ARInvoiceRepository : IARInvoiceRepository
    {
        private readonly FTDBWContext _ftdbwcontext;
        public ARInvoiceRepository(FTDBWContext ftdbwcontext) => _ftdbwcontext = ftdbwcontext;
        public async Task AddARInvoiceAsync(ARInvoiceHeader invoiceHeader)
        {
            await _ftdbwcontext.FTOINV.AddAsync(invoiceHeader);
        }
        public async Task AddRangeAsync(List<ARInvoiceHeader> invoice)
        {
            await _ftdbwcontext.FTOINV.AddRangeAsync(invoice);
        }

        public async Task<ARInvoiceHeader?> CheckSubmitId(string submitId)
        {
            return  await _ftdbwcontext.FTOINV.FirstOrDefaultAsync(el => el.SubmitId == submitId);
        }

        public async Task<List<ARInvoiceHeader>?> GetInquiryAsync(string submitId)
        {
            return await _ftdbwcontext.FTOINV.Where(x => x.SubmitId == submitId).ToListAsync();
        }

        public async Task<ARInvoiceHeader?> GetStatusAsync(Guid id)
        {
            return await _ftdbwcontext.FTOINV.FindAsync(id);
        }

        public async Task<ARInvoiceHeader?> GetStatusAsync(string refnum)
        {
            return await _ftdbwcontext.FTOINV.FirstOrDefaultAsync(x => x.U_RefNum == refnum);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _ftdbwcontext.SaveChangesAsync();
        }


    }
}
