using AutoMapper;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.Helpers;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;

namespace FTSI_Web_API_System_Integration.Services
{
    public class ARInvoiceService
    {
        private readonly IARInvoiceRepository _aRInvoiceRepository;
        private readonly IMapper _mapper;

        public ARInvoiceService(IARInvoiceRepository arInvoicerepository, IMapper mapper)
        {
            _aRInvoiceRepository = arInvoicerepository;
            _mapper = mapper;
        }

        public async Task<ARInvoiceHeader?> GetStatusAsync(string refnum)
        {
            return await _aRInvoiceRepository.GetStatusAsync(refnum);
        }

        public async Task<List<ARInvoiceHeader>?> GetInquiryAsync(string refnum)
        {
            return await _aRInvoiceRepository.GetInquiryAsync(refnum);
        }

        public async Task<List<ARInvoiceHeader>> AddRangeAsync(PostARInvoiceItemsDTO dto)
        {

            DateTime createdAt = DateTime.Now;
            int lineNum;

            List<ARInvoiceHeader> headers = _mapper.Map<List<ARInvoiceHeader>>(dto.Data);

            foreach (ARInvoiceHeader header in headers)
            {
                header.SubmitId = dto.SubmitId;
                header.DocType = DocType.Service;
                header.CreatedAt = createdAt;

                foreach (ARInvoiceLines line in header.DocumentLines)
                {
                    line.CreatedAt = createdAt;
                }

                lineNum = 0;
                foreach (ARInvoiceWTax tax in header.DocumentWTax)
                {
                    tax.LineNum = lineNum;
                    tax.CreatedAt = createdAt;
                    lineNum++;
                }

            }

            await _aRInvoiceRepository.AddRangeAsync(headers);
            await _aRInvoiceRepository.SaveChangesAsync();

            return headers;
        }

        public async Task<List<ARInvoiceHeader>> AddRangeAsync(PostARInvoiceServicesDTO dto)
        {
            DateTime createdAt = DateTime.Now;
            int lineNum;


            List<ARInvoiceHeader> headers = _mapper.Map<List<ARInvoiceHeader>>(dto.Data);

            foreach (ARInvoiceHeader header in headers)
            {
                header.SubmitId = dto.SubmitId;
                header.DocType = DocType.Service;
                header.CreatedAt = createdAt;

                foreach (ARInvoiceLines line in header.DocumentLines)
                {
                    line.CreatedAt = createdAt;
                }

                lineNum = 0;
                foreach (ARInvoiceWTax tax in header.DocumentWTax)
                {
                    tax.LineNum = lineNum;
                    tax.CreatedAt = createdAt;
                    lineNum++;
                }

            }

            await _aRInvoiceRepository.AddRangeAsync(headers);
            await _aRInvoiceRepository.SaveChangesAsync();

            return headers;
        }

        public async Task<bool> IsValidSubmitId(string submitId)
        {
            // Check Submit Id
            ARInvoiceHeader? invoice = await _aRInvoiceRepository.CheckSubmitId(submitId);

            if (invoice != null)
            {
                return true;

            }

            return false;
        }
    }
}

