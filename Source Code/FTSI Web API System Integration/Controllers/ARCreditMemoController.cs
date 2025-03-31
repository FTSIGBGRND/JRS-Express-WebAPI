using FTSI_Web_API_System_Integration.DTOs;
using FTSI_Web_API_System_Integration.DTOs.ARCreditMemo;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using FTSI_Web_API_System_Integration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FTSI_Web_API_System_Integration.Controllers
{
    [Route("api/documents/arcreditmemo")]
    [ApiController]
    [Authorize]
    public class ARCreditMemoController : ControllerBase
    {
        private readonly ARCreditMemoService _service;

        public ARCreditMemoController(ARCreditMemoService service)
        {
            _service = service;
        }

        #region Item Endpoint
        //// POST api/<ARInvoiceController>
        //[HttpPost("item")]
        //public async Task<ActionResult<PostResponse>> PostItem([FromBody] ARCreditMemoItemHeaderDTO dto)
        //{
        //    ARCreditMemoHeader header;

        //    try
        //    {
        //        header = await _service.AddAsync(dto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new PostResponse { Status = "Error", Message = ex.Message, Data = new PostResponseData { U_RefNum = dto.U_RefNum ?? "" } });
        //    }

        //    return Ok(new PostResponse { Status = "Success", Message = "Successfully Saved.", Data = new PostResponseData { Id = header.Id, U_RefNum = header.U_RefNum ?? "" } });
        //}
        #endregion

        #region Service Endpoint
        [HttpPost("services")]
        public async Task<ActionResult<PostRangeResponse>> PostARCreditMemoService([FromBody] PostARCreditMemoServicesDTO dto)
        {
            List<ARCreditMemoHeader> headers;

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
            foreach (ARCreditMemoHeader invoice in headers)
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

                List<ARCreditMemoHeader>? documents = [];
                documents = await _service.GetInquiryAsync(submitId);

                if (documents == null)
                {
                    throw new Exception("Failed to retrieve data.");
                }

                processDocumentCount = documents.Count;

                foreach (var document in documents)
                {
                    processDocument.Add(new ProcessDocument
                    {
                        Id = document.Id,
                        U_RefNum = document.U_RefNum,
                        IntegrationStatus = document.IntegrationStatus,
                        IntegrationMessage = document.IntegrationMessage
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

        #region Cancellation Endpoint
        //[HttpPost("cancel/{id}")]
        //public async Task<ActionResult<PostResponse>> Cancel(Guid id)
        //{

        //    ARCreditMemoHeader header = new ARCreditMemoHeader();
        //    string integStatus = string.Empty;

        //    try
        //    {
        //        header = await _service.GetStatusAsync(id);

        //        if (header == null)
        //        {
        //            return NotFound(new PostResponse { Status = "Error", Message = $"Id [{id}] Not Found.", Data = new PostResponseData { Id = id, U_RefNum = "" } });
        //        }

        //        if (header.Canceled == 'Y')
        //        {
        //            return UnprocessableEntity(new PostResponse { Status = "Error", Message = $"Document already cancelled on {header.CancelDate}", Data = new PostResponseData { Id = id, U_RefNum = header.U_RefNum } });
        //        }

        //        if (header.IntegrationStatus != 'S')
        //        {
        //            return UnprocessableEntity(new PostResponse { Status = "Error", Message = "Cannot cancel not posted documents", Data = new PostResponseData { Id = id, U_RefNum = header.U_RefNum } });
        //        }

        //        await _service.CancelAsync(header);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new PostResponse { Status = "Error", Message = ex.Message, Data = new PostResponseData { U_RefNum = header.U_RefNum, Id = id } });
        //    }

        //    return Ok(new PostResponse { Status = "Success", Message = "Cancellation Successfully Saved.", Data = new PostResponseData { Id = header.Id, U_RefNum = header.U_RefNum} });
        //}
        #endregion
    }
}


