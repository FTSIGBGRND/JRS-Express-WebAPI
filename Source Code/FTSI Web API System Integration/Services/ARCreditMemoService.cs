using AutoMapper;
using FTSI_Web_API_System_Integration.Data;
using FTSI_Web_API_System_Integration.DTOs.ARCreditMemo;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.Helpers;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.Base.Document;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using Microsoft.JSInterop.Infrastructure;
using NuGet.Protocol.Core.Types;
using System;

namespace FTSI_Web_API_System_Integration.Services
{
    public class ARCreditMemoService
    {
        private readonly IARCreditMemoRepository _repository;
        private readonly IMapper _mapper;

        public ARCreditMemoService(IARCreditMemoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ARCreditMemoHeader> GetStatusAsync(Guid id)
        {
            return await _repository.GetStatusAsync(id);
        }

        //public async Task<ARCreditMemoHeader> CancelAsync(ARCreditMemoHeader entity)
        //{
        //    // Update Cancel Field and CancelDate Field
        //    entity.Canceled = 'Y';
        //    entity.CancelDate = DateTime.Now;
        //    entity.IntegrationStatus = 'P';

        //    _repository.Update(entity);
        //    await _repository.SaveChangesAsync();

        //    return entity;
        //}

        public async Task<bool> IsValidSubmitId(string submitId)
        {
            // Check Submit Id
            ARCreditMemoHeader? invoice = await _repository.CheckSubmitId(submitId);

            if (invoice != null)
            {
                return true;

            }

            return false;
        }

        public async Task<List<ARCreditMemoHeader>> AddRangeAsync(PostARCreditMemoServicesDTO dto)
        {
            DateTime createdAt = DateTime.Now;
            int lineNum;


            List<ARCreditMemoHeader> headers = _mapper.Map<List<ARCreditMemoHeader>>(dto.Data);

            foreach (ARCreditMemoHeader header in headers)
            {
                header.SubmitId = dto.SubmitId;
                header.DocType = DocType.Service;
                header.CreatedAt = createdAt;

                foreach (ARCreditMemoLines line in header.DocumentLines)
                {
                    line.CreatedAt = createdAt;
                }

                if (header.DocumentWTax != null)
                {
                    lineNum = 0;
                    foreach (ARCreditMemoWTax tax in header.DocumentWTax)
                    {
                        tax.LineNum = lineNum;
                        tax.CreatedAt = createdAt;
                        lineNum++;
                    }
                }

            }

            await _repository.AddRangeAsync(headers);
            await _repository.SaveChangesAsync();

            return headers;
        }

        public async Task<List<ARCreditMemoHeader>> GetInquiryAsync(string submitId)
        {
            return await _repository.GetInquiryAsync(submitId);
        }
    }
}