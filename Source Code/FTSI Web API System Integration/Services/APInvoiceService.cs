using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.Helpers;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using NuGet.Protocol.Core.Types;

namespace FTSI_Web_API_System_Integration.Services
{
    public class APInvoiceService
    {
        private readonly IAPInvoiceRepository _repo;

        public APInvoiceService(IAPInvoiceRepository repo)
        {
            _repo = repo;
        }

        public async Task<APInvoiceHeader> GetStatusAsync(Guid id)
        {
            return await _repo.GetStatusAsync(id);
        }

        public async Task<APInvoiceHeader> AddAsync(APInvoiceServiceHeaderDTO invoiceDTO)
        {

            DateTime createdAt = DateTime.Now;
            List<APInvoiceLines> lines = [];
            APInvoiceWTax wtax = new();
            APInvoiceHeader header = new();

            // Get Lines
            foreach (APInvoiceServiceLinesDTO line in invoiceDTO.DocumentLines)
            {
                lines.Add(new()
                {
                    LineNum = line.LineNum,
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
            if (invoiceDTO.DocumentWTax != null)
            {
                wtax.WTCode = invoiceDTO.DocumentWTax?.WTCode;
                wtax.TaxbleAmnt = invoiceDTO.DocumentWTax?.TaxbleAmnt;
                wtax.WTAmnt = invoiceDTO.DocumentWTax?.WTAmnt;
                wtax.U_RefNum = invoiceDTO.DocumentWTax?.U_RefNum;
                wtax.CreatedAt = createdAt;
            };

            // Get Header
            header.CardCode = invoiceDTO.CardCode;
            header.CardName = invoiceDTO.CardName;
            header.DocDate = invoiceDTO.DocDate;
            header.DocDueDate = invoiceDTO.DocDueDate;
            header.DocType = DocType.Service;
            header.TaxDate = invoiceDTO.TaxDate;
            header.NumAtCard = invoiceDTO.NumAtCard;
            header.JrnlMemo = invoiceDTO.JrnlMemo;
            header.Comments = invoiceDTO.Comments;
            header.U_RefNum = invoiceDTO.U_RefNum;
            header.DocumentLines = lines;
            header.DocumentWTax = wtax;
            header.CreatedAt = createdAt;


            await _repo.AddAsync(header);
            await _repo.SaveChangesAsync();

            return header;
        }

        public async Task<APInvoiceHeader> AddAsync(APInvoiceItemHeaderDTO invoiceDTO)
        {

            DateTime createdAt = DateTime.Now;
            List<APInvoiceLines> lines = [];
            APInvoiceWTax wtax = new();
            APInvoiceHeader header = new();

            // Get Lines
            foreach (APInvoiceItemLinesDTO line in invoiceDTO.DocumentLines)
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
            if (invoiceDTO.DocumentWTax != null)
            {
                wtax.WTCode = invoiceDTO.DocumentWTax?.WTCode;
                wtax.TaxbleAmnt = invoiceDTO.DocumentWTax?.TaxbleAmnt;
                wtax.WTAmnt = invoiceDTO.DocumentWTax?.WTAmnt;
                wtax.U_RefNum = invoiceDTO.DocumentWTax?.U_RefNum;
                wtax.CreatedAt = createdAt;
            };

            // Get Header
            header.CardCode = invoiceDTO.CardCode;
            header.CardName = invoiceDTO.CardName;
            header.DocDate = invoiceDTO.DocDate;
            header.DocDueDate = invoiceDTO.DocDueDate;
            header.TaxDate = invoiceDTO.TaxDate;
            header.NumAtCard = invoiceDTO.NumAtCard;
            header.JrnlMemo = invoiceDTO.JrnlMemo;
            header.Comments = invoiceDTO.Comments;
            header.U_RefNum = invoiceDTO.U_RefNum;
            
            header.DocumentLines = lines;
            header.DocumentWTax = wtax;
            header.CreatedAt = createdAt;

            await _repo.AddAsync(header);
            await _repo.SaveChangesAsync();

            return header;
        }
    }
}
