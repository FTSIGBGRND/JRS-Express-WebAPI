using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.UserDefined.DocumentUDF
{
    public class DocumentLinesUDF
    {
        #region User-Defined Fields
        [MaxLength(30)]
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
        #endregion
    }
}
