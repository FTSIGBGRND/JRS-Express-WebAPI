using AutoMapper;
using FTSI_Web_API_System_Integration.DTOs.ARCreditMemo;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.DTOs.IncomingPayment;
using FTSI_Web_API_System_Integration.Helpers;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.IncomingPayment;

namespace FTSI_Web_API_System_Integration.Services
{
    public class IncomingPaymentService
    {
        private readonly IIncomingPaymentRepository _repository;
        private readonly IMapper _mapper;

        public IncomingPaymentService(IIncomingPaymentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IncomingPaymentHeader?> GetStatusAsync(Guid id)
        {
            return await _repository.GetStatusAsync(id);
        }

        public async Task<bool> IsValidSubmitId(string submitId)
        {
            // Check Submit Id
            IncomingPaymentHeader? invoice = await _repository.CheckSubmitId(submitId);

            if (invoice != null)
            {
                return true;

            }

            return false;
        }

        public async Task<List<IncomingPaymentHeader>> AddRangeAsync(PostIncomingPaymentsDTO dto)
        {
            DateTime createdAt = DateTime.Now;
            int lineNum;

            List<IncomingPaymentHeader> headers = _mapper.Map<List<IncomingPaymentHeader>>(dto.Data);

            foreach (IncomingPaymentHeader header in headers)
            {
                header.SubmitId = dto.SubmitId;
                header.CreatedAt = createdAt;

                lineNum = 0;
                foreach (IncomingPaymentInvoices line in header.PaymentInvoices)
                {
                    line.LineNum = 0;
                    line.CreatedAt = createdAt;
                    lineNum++;
                }

                lineNum = 0;
                foreach (IncomingPaymentChecks check in header.PaymentChecks)
                {
                    check.LineID = 0;
                    check.CreatedAt = createdAt;
                    lineNum++;
                }

                foreach (IncomingPaymentCreditCard creditCard in header.PaymentCreditCard)
                {
                    creditCard.CreatedAt = createdAt; 
                }
            }

            await _repository.AddRangeAsync(headers);
            await _repository.SaveChangesAsync();

            return headers;
        }

        public async Task<List<IncomingPaymentHeader>?> GetInquiryAsync(string refnum)
        {
            return await _repository.GetInquiryAsync(refnum);
        }
    }
}