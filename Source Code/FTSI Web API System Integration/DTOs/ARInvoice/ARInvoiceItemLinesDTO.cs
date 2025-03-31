using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FTSI_Web_API_System_Integration.DTOs.ARInvoice
{
    public class ARInvoiceItemLinesDTO
    {
        [Required]
        public int LineNum { get; set; }

        [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters!")]
        public string? Dscription { get; set; }

        [MaxLength(15, ErrorMessage = "Account Code cannot exceed 15 characters!")]
        [Required]
        public string? AcctCode { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? DiscPrcnt { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? UnitPrice { get; set; }

        [MaxLength(4, ErrorMessage = "Account Code cannot exceed 8 characters!")]
        [Required]
        public string? VatGroup { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        [Required]
        public decimal? PriceAfVAT { get; set; }

        [RegularExpression("^(N|Y)$", ErrorMessage = "Invalid Value. Withholding Tax Liable Valid Values are Y and N (Y - Yes | N - No)!")]
        [DefaultValue("N")]
        public string? WTLiable { get; set; }

        [MaxLength(8, ErrorMessage = "Cost Center Code Dimension 1 cannot exceed 8 characters!")]
        public string? OcrCode { get; set; }

        [MaxLength(8, ErrorMessage = "Cost Center Code Dimension 2 cannot exceed 8 characters!")]
        public string? OcrCode2 { get; set; }

        [MaxLength(8, ErrorMessage = "Cost Center Code Dimension 3 cannot exceed 8 characters!")]
        public string? OcrCode3 { get; set; }

        [MaxLength(8, ErrorMessage = "Cost Center Code Dimension 4 cannot exceed 8 characters!")]
        public string? OcrCode4 { get; set; }

        [MaxLength(8, ErrorMessage = "Cost Center Code Dimension 5 cannot exceed 8 characters!")]
        public string? OcrCode5 { get; set; }

        [MaxLength(30, ErrorMessage = "Document Line Reference Number cannot exceed 30 characters!")]
        public string? U_RefNum { get; set; }

        [MaxLength(30)]
        public string? U_xWTVendor { get; set; }

        [MaxLength(30)]
        public string? U_xTaxbleAmnt { get; set; }

        [MaxLength(30)]
        public string? U_xTaxAmnt { get; set; }

        [MaxLength(30)]
        public string? U_xSupplierName { get; set; }

        [MaxLength(30)]
        public string? U_xAddress { get; set; }

        [MaxLength(30)]
        public string? U_xTINnumber { get; set; }

        [MaxLength(30)]
        public string? U_xCardType { get; set; }

        [MaxLength(30)]
        public string? U_SalesType { get; set; }
    }
}
