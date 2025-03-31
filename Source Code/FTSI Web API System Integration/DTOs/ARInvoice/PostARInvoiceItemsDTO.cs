using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.DTOs.ARInvoice
{
    public class PostARInvoiceItemsDTO
    {
        [Required]
        [MaxLength(30)]
        public string? SubmitId { get; set; }

        [Required]
        public List<ARInvoiceItemHeaderDTO> Data { get; set; } = [];
    }
}
