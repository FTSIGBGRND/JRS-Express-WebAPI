﻿using FTSI_Web_API_System_Integration.Models.BusinessObjects.BusinessPartner;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.DTOs.BusinessPartner
{
    public class BusinessPartnerHeaderDTO
    {
        [MaxLength(15)]
        [Required]
        public string? CardCode { get; set; }

        [MaxLength(100)]
        [Required]
        public string? CardName { get; set; }

        [MaxLength(100)]
        public string? CardFName { get; set; }

        /// <value>
        /// C - Customer, S - Vendor, L - Lead
        /// </value>
        [RegularExpression("^(C|S|L)$", ErrorMessage = "Invalid Value. Document Type Valid Values are C - Customer, S - Vendor, L - Lead!")]
        [DefaultValue('C')]
        public char CardType { get; set; } = 'C';

        public int? GroupCode { get; set; }

        /// <value>
        /// C - Company, 
        /// I - Private, 
        /// G - Government, 
        /// E - Employee
        /// </value>
        /// 
        [RegularExpression("^(C|I|G|E)$", ErrorMessage = "Invalid Value. Document Type Valid Values are C - Company, I - Private, G - Government, E - Employee!")]
        [DefaultValue('C')]
        public char CmpPrivate { get; set; } = 'C';

        [DefaultValue('Y')]
        public char ValidFor { get; set; }

        [MaxLength(8)]
        public string? ECVatGroup { get; set; }

        [MaxLength(64)]
        public string? AddId { get; set; }

        public int? IndustryC { get; set; }

        [MaxLength(30)]
        public string? ValidComm { get; set; }

        [MaxLength(32)]
        public string? LicTradNum { get; set; }

        [MaxLength(50)]
        public string? DflAccount { get; set; }

        public int? GroupNum { get; set; }

        [MaxLength(255)]
        public string? DflBranch { get; set; }

        [MaxLength(255)]
        public string? U_CstmNmSrch { get; set; }

        [MaxLength(255)]
        public string? U_CstmrCtgry { get; set; }

        [MaxLength(255)]
        public string? U_CstmrCdHQ { get; set; }

        [MaxLength(255)]
        public string? U_CutmrNtr { get; set; }

        [MaxLength(255)]
        public string? U_PsicPsoc { get; set; }

        [MaxLength(255)]
        public string? U_CrdtRtng { get; set; }

        [MaxLength(255)]
        public string? U_CrdRtUp { get; set; }

        [MaxLength(255)]
        public string? U_CrdtRtDtl { get; set; }

        [MaxLength(255)]
        public string? U_CrdtCtgry { get; set; }

        [MaxLength(255)]
        public string? U_VndrPrgrm { get; set; }

        [MaxLength(255)]
        public string? U_GrgCtgry { get; set; }

        [MaxLength(255)]
        public string? U_EqtyRt { get; set; }

        [MaxLength(255)]
        public string? U_OpePrd { get; set; }

        [MaxLength(255)]
        public string? U_ExpsrLmt { get; set; }

        [MaxLength(255)]
        public string? U_IDCrdAdd { get; set; }

        [MaxLength(255)]
        public string? U_MrtlStatus { get; set; }

        [MaxLength(255)]
        public string? U_Emplymnt { get; set; }

        [MaxLength(255)]
        public string? U_PrtsCmpyCd { get; set; }

        [MaxLength(255)]
        public string? U_PrtsCmpyNm { get; set; }

        [MaxLength(255)]
        public string? U_OrgnlGrpCd { get; set; }

        [MaxLength(255)]
        public string? U_OrgnlGrpNm { get; set; }

        [MaxLength(255)]
        public string? U_InvRtio { get; set; }

        [MaxLength(255)]
        public string? U_IntrdcrCd { get; set; }

        [MaxLength(255)]
        public string? U_IntrdcrNm { get; set; }

        [MaxLength(255)]
        public string? U_GrntrCd { get; set; }

        [MaxLength(255)]
        public string? U_AssetSize { get; set; }

        [MaxLength(255)]
        public string? U_TcCRR { get; set; }
        [MaxLength(255)]
        public string? U_PostCode { get; set; }

        [MaxLength(255)]
        public string? U_PrfssnType { get; set; }

        [MaxLength(255)]
        public string? U_Privies { get; set; }

        [MaxLength(255)]
        public string? U_FsclMnth { get; set; }

        [MaxLength(255)]
        public string? U_RgstrdCptl { get; set; }

        [MaxLength(255)]
        public string? U_EsblsmntDt { get; set; }

        [MaxLength(255)]
        public string? U_MngmntYrs { get; set; }

        [MaxLength(255)]
        public string? U_HeadCount { get; set; }

        [MaxLength(255)]
        public string? U_Credibility { get; set; }

        [MaxLength(255)]
        public string? U_RiskConcern { get; set; }

        [MaxLength(255)]
        public string? U_CstmerVst { get; set; }

        [MaxLength(255)]
        public string? U_WhtRcvd { get; set; }

        [MaxLength(255)]
        public string? U_SlsPicFl { get; set; }

        [MaxLength(255)]
        public string? U_SlsPicOI { get; set; }

        [MaxLength(255)]
        public string? U_SlsMngr9 { get; set; }

        [MaxLength(255)]
        public string? U_SlsMngr10 { get; set; }

        [MaxLength(255)]
        public string? U_CrdtAnlyst { get; set; }

        [MaxLength(255)]
        public string? U_HoldingCR { get; set; }

        [MaxLength(255)]
        public string? U_InCbnt { get; set; }

        [MaxLength(255)]
        public string? U_BzLink { get; set; }

        [MaxLength(255)]
        public string? U_DueDate { get; set; }

        [MaxLength(255)]
        public string? U_InvDvncDt { get; set; }

        [MaxLength(255)]
        public string? U_InvoicePIC { get; set; }

        [MaxLength(255)]
        public string? U_IBllngPic { get; set; }

        [MaxLength(255)]
        public string? U_SndngMthd { get; set; }

        [MaxLength(255)]
        public string? U_DescriptionPtn { get; set; }

        [MaxLength(255)]
        public string? U_ReceiptDsp { get; set; }

        [MaxLength(255)]
        public string? U_BranchID { get; set; }

        [MaxLength(255)]
        public string? U_BranchName { get; set; }

        [MaxLength(255)]
        public string? U_OffclCtgry { get; set; }

        [MaxLength(255)]
        public string? U_GrntLttrDt { get; set; }

        [MaxLength(255)]
        public string? U_AgrAcvtyCd { get; set; }

        [MaxLength(255)]
        public string? U_EcAcvtyCd { get; set; }

        [MaxLength(255)]
        public string? U_InvPrntPtrn { get; set; }

        [MaxLength(255)]
        public string? U_CreditTerm { get; set; }

        [MaxLength(30)]
        public string? U_RefNum { get; set; }

        public List<BPAddressDTO>? Addresses { get; set; } = [];

        public List<ContactEmployeeDTO>? ContactEmployees { get; set; } = [];
    }
}
