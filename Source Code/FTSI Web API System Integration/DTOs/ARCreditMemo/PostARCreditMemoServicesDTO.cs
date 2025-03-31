using FTSI_Web_API_System_Integration.DTOs.ARCreditMemo;
using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.DTOs.ARInvoice
{
    public class PostARCreditMemoServicesDTO
    {
        [Required]
        [MaxLength(30)]
        public string? SubmitId { get; set; }

        [Required]
        public List<ARCreditMemoServiceHeaderDTO> Data { get; set; } = [];
    }
}
