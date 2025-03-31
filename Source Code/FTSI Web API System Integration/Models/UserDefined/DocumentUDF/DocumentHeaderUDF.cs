using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.Models.UserDefined.DocumentUDF
{
    public class DocumentHeaderUDF
    {
        [MaxLength(30)]
        public string? U_RefNum { get; set; }

        /// <summary>
        /// Status of SAP and Web API Integration.
        /// </summary>
        /// <value>
        /// P - Pending, S - Success, E - Error
        /// </value>
        public char IntegrationStatus { get; set; } = 'P';

        public string? IntegrationMessage { get; set; }

        #region JRS Express
        [MaxLength(100)]
        public string U_JRSBranch { get; set; }

        [MaxLength(100)]
        public string U_TransactionType { get; set; }

        [MaxLength(100)]
        [Required]
        public string U_SalesType { get; set; }

        [MaxLength(100)]
        public string U_ParentBP { get; set; }

        [MaxLength(100)]
        public string U_AirwayBillNo { get; set; }
        #endregion
    }
}
