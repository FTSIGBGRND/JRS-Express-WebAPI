using FTSI_Web_API_System_Integration.DTOs;
using FTSI_Web_API_System_Integration.DTOs.IncomingPayment;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.IncomingPayment;
using FTSI_Web_API_System_Integration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FTSI_Web_API_System_Integration.Controllers
{
    [Route("api/payments/incoming")]
    [ApiController]
    [Authorize]
    public class IncomingPaymentController : ControllerBase
    {
        private readonly IncomingPaymentService _service;

        public IncomingPaymentController(IncomingPaymentService service)
        {
            _service = service;
        }

        #region Incoming Payments
        [HttpPost]
        public async Task<ActionResult<PostResponse>> Post([FromBody] PostIncomingPaymentsDTO dto)
        {
            List<IncomingPaymentHeader> headers;

            try
            {
                if (string.IsNullOrEmpty(dto.SubmitId))
                {
                    return BadRequest(new ErrorStatusDTO { Status = "0", ErrorDetails = new ErrorDetails { ErrorCode = "E01", ErrorMessage = "SubmitId Is Required!" } });
                }

                if (await _service.IsValidSubmitId(dto.SubmitId))
                {
                    return BadRequest(new ErrorStatusDTO { Status = "0", ErrorDetails = new ErrorDetails { ErrorCode = "E02", ErrorMessage = $"SubmitId [{dto.SubmitId}] Already Exist!" } });
                }

                headers = await _service.AddRangeAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorStatusDTO { Status = "0", ErrorDetails = new ErrorDetails { ErrorCode = "E99", ErrorMessage = ex.Message } });
            }

            List<PostedData> datas = [];
            foreach (IncomingPaymentHeader header in headers)
            {
                datas.Add(new PostedData
                {
                    Id = header.Id,
                    U_RefNum = header.U_RefNum
                });
            }

            return Ok(new SuccessStatusDTO { Data = datas });
        }
        #endregion

        #region Inquiry Endpoint
        [HttpGet("inquiry/{submitId}")]
        public async Task<ActionResult<InquiryResultDTO>> GetInquiry(string submitId)
        {

            List<ProcessDocument>? processDocument = [];
            int processDocumentCount;
            try
            {
                if (!await _service.IsValidSubmitId(submitId))
                {
                    return NotFound(new ErrorStatusDTO { Status = "0", ErrorDetails = new ErrorDetails { ErrorCode = "E03", ErrorMessage = $"SubmitId [{submitId}] Not Found." } });
                }

                List<IncomingPaymentHeader>? payments = [];
                payments = await _service.GetInquiryAsync(submitId);

                if (payments == null)
                {
                    throw new Exception("Failed to retrieve data.");
                }

                processDocumentCount = payments.Count;

                foreach (var invoice in payments)
                {
                    processDocument.Add(new ProcessDocument
                    {
                        Id = invoice.Id,
                        U_RefNum = invoice.U_RefNum,
                        IntegrationStatus = invoice.IntegrationStatus,
                        IntegrationMessage = invoice.IntegrationMessage
                    });
                }


            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorStatusDTO { Status = "0", ErrorDetails = new ErrorDetails { ErrorCode = "E99", ErrorMessage = ex.Message } }); ;
            }

            return Ok(new InquiryResultDTO { Status = "1", Data = new InquiryResultData { SubmitId = submitId, TotalCountQty = processDocumentCount, ProcessDocuments = processDocument } });
        }
        #endregion
    }
}
