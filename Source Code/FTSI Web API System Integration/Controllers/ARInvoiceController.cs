using FTSI_Web_API_System_Integration.DTOs;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using FTSI_Web_API_System_Integration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FTSI_Web_API_System_Integration.Controllers
{
    [Route("api/documents/arinvoice")]
    [ApiController]
    [Authorize]
    public class ARInvoiceController : ControllerBase
    {
        private readonly ARInvoiceService _service;

        public ARInvoiceController(ARInvoiceService service)
        {
            _service = service;
        }

        #region Item Endpoint
        //[HttpPost("items")]
        //public async Task<ActionResult<PostRangeResponse>> PostARInvoiceItems([FromBody] PostARInvoiceItemsDTO dto)
        //{
        //    List<ARInvoiceHeader> arInvoiceHeaders;

        //    try
        //    {
        //        if (string.IsNullOrEmpty(dto.SubmitId))
        //        {
        //            return BadRequest(new ErrorStatusDTO { Status = "0", ErrorDetails = new ErrorDetails { ErrorCode = "E01", ErrorMessage = "SubmitId Is Required!" } });
        //        }

        //        if (await _service.IsValidSubmitId(dto.SubmitId))
        //        {
        //            return BadRequest(new ErrorStatusDTO { Status = "0", ErrorDetails = new ErrorDetails { ErrorCode = "E02", ErrorMessage = $"SubmitId [{dto.SubmitId}] Already Exist!" } });
        //        }

        //        arInvoiceHeaders = await _service.AddRangeAsync(dto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new ErrorStatusDTO { Status = "0", ErrorDetails = new ErrorDetails { ErrorCode = "E99", ErrorMessage = ex.Message } });
        //    }

        //    List<PostedData> datas = [];
        //    foreach (ARInvoiceHeader invoice in arInvoiceHeaders)
        //    {
        //        datas.Add(new PostedData
        //        {
        //            Id = invoice.Id,
        //            U_RefNum = invoice.U_RefNum
        //        });
        //    }

        //    return Ok(new SuccessStatusDTO { Data = datas });
        //}
        #endregion

        #region Service Endpoint
        [HttpPost("services")]
        public async Task<ActionResult<PostRangeResponse>> PostARInvoiceService([FromBody] PostARInvoiceServicesDTO dto)
        {
            List<ARInvoiceHeader> arInvoiceHeaders;

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

                arInvoiceHeaders = await _service.AddRangeAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorStatusDTO { Status = "0", ErrorDetails = new ErrorDetails { ErrorCode = "E99", ErrorMessage = ex.Message } });
            }

            List<PostedData> datas = [];
            foreach (ARInvoiceHeader invoice in arInvoiceHeaders)
            {
                datas.Add(new PostedData
                {
                    Id = invoice.Id,
                    U_RefNum = invoice.U_RefNum
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

                List<ARInvoiceHeader>? arInvoices = [];
                arInvoices = await _service.GetInquiryAsync(submitId);

                if (arInvoices == null)
                {
                    throw new Exception("Failed to retrieve data.");
                }

                processDocumentCount = arInvoices.Count;

                foreach (var invoice in arInvoices)
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

        #region Check Status Endpoint

        //[HttpGet("status/{refnum}")]
        //public async Task<ActionResult<GetResponse>> GetStatus(string refnum)
        //{

        //    ARInvoiceHeader? arInvoice = new ARInvoiceHeader();
        //    string integStatus = string.Empty;

        //    try
        //    {
        //        arInvoice = await _service.GetStatusAsync(refnum);

        //        if (arInvoice == null)
        //        {
        //            return NotFound(new GetResponse { Status = "Error", Message = $"RefNum [{refnum}] Not Found.", Data = new GetResponseData { U_RefNum = refnum } });
        //        }

        //        switch (arInvoice.IntegrationStatus)
        //        {
        //            case 'P':
        //                integStatus = "Pending";
        //                break;
        //            case 'E':
        //                integStatus = "Error";
        //                break;
        //            case 'S':
        //                integStatus = "Success";
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new PostResponse { Status = "Error", Message = ex.Message, Data = new PostResponseData { U_RefNum = refnum } });
        //    }

        //    return Ok(new GetResponse { Status = "Success", Message = "Integration Status Successfully Retrieved.", Data = new GetResponseData { IntegrationStatus = integStatus, IntegrationMessage = arInvoice.IntegrationMessage ?? "", U_RefNum = arInvoice.U_RefNum ?? "", Id = arInvoice.Id } });
        //}
        #endregion
    }
}
