using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.DTOs.ARInvoice
{
    public class PostARInvoiceServicesDTO
    {
        [Required]
        [MaxLength(30)]
        public string? SubmitId { get; set; }

        [Required]
        public List<ARInvoiceServiceHeaderDTO> Data { get; set; } = [];
    }
}
