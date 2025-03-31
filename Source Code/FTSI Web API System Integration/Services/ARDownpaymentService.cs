using FTSI_Web_API_System_Integration.DTOs.ARCreditMemo;
using FTSI_Web_API_System_Integration.DTOs.ARDownpayment;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARDownPayment;

namespace FTSI_Web_API_System_Integration.Services
{
    public class ARDownpaymentService
    {
        private readonly IARDownpaymentRepository _repository;

        public ARDownpaymentService(IARDownpaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ARDownpaymentHeader?> GetStatusAsync(Guid id)
        {
            return await _repository.GetStatusAsync(id);
        }

        public async Task<ARDownpaymentHeader> AddAsync(ARDownpaymentHeaderDTO dto)
        {
            DateTime createdAt = DateTime.Now;

            // Get Lines
            List<ARDownpaymentLines> lines = new();
            foreach (ARDownpaymentLinesDTO line in dto.DocumentLines)
            {
                lines.Add(new()
                {
                    LineNum = line.LineNum,
                    ItemCode = line.ItemCode,
                    DiscPrcnt = line.DiscPrcnt,
                    Quantity = line.Quantity,
                    VatGroup = line.VatGroup,
                    PriceAfVAT = line.PriceAfVAT,
                    WTLiable = line.WTLiable,
                    OcrCode = line.OcrCode,
                    OcrCode2 = line.OcrCode2,
                    OcrCode3 = line.OcrCode3,
                    OcrCode4 = line.OcrCode4,
                    OcrCode5 = line.OcrCode5,
                    U_RefNum = line.U_RefNum,
                    CreatedAt = createdAt
                });
            }

            // Get WTax
            ARDownpaymentWTax wtax = new()
            {
                WTCode = dto.DocumentWTax.WTCode,
                TaxbleAmnt = dto.DocumentWTax.TaxbleAmnt,
                WTAmnt = dto.DocumentWTax.WTAmnt,
                U_RefNum = dto.DocumentWTax.U_RefNum,
                CreatedAt = createdAt
            };

            // Get Header
            ARDownpaymentHeader header = new()
            {
                CardCode = dto.CardCode,
                CardName = dto.CardName,
                DocDate = dto.DocDate,
                DocDueDate = dto.DocDueDate,
                TaxDate = dto.TaxDate,
                NumAtCard = dto.NumAtCard,
                DocType = dto.DocType,
                JrnlMemo = dto.JrnlMemo,
                Comments = dto.Comments,
                U_RefNum = dto.U_RefNum,
                Canceled = dto.Canceled,
                DocumentLines = lines,
                DocumentWTax = wtax,
                CreatedAt = createdAt
            };

            await _repository.AddAsync(header);
            await _repository.SaveChangesAsync();

            return header;
        }
    }
}
