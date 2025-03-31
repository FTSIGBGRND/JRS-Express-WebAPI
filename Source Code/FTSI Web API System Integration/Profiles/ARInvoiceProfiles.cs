using AutoMapper;
using FTSI_Web_API_System_Integration.DTOs.ARCreditMemo;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.DTOs.IncomingPayment;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.IncomingPayment;

namespace FTSI_Web_API_System_Integration.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            #region AR Invoice Profiles
            CreateMap<ARInvoiceHeader, ARInvoiceServiceHeaderDTO>().ReverseMap();
            CreateMap<ARInvoiceLines, ARInvoiceServiceLinesDTO>().ReverseMap();
            CreateMap<ARInvoiceHeader, ARInvoiceItemHeaderDTO>().ReverseMap();
            CreateMap<ARInvoiceLines, ARInvoiceItemLinesDTO>().ReverseMap();
            CreateMap<ARInvoiceWTax, ARInvoiceWTaxDTO>().ReverseMap();
            #endregion

            #region AR Credit Memo Profiles
            CreateMap<ARCreditMemoHeader, ARCreditMemoServiceHeaderDTO>().ReverseMap();
            CreateMap<ARCreditMemoLines, ARCreditMemoServiceLinesDTO>().ReverseMap();
            CreateMap<ARCreditMemoWTax, ARCreditMemoWTaxDTO>().ReverseMap();
            #endregion

            #region Incoming Payments Profiles
            CreateMap<IncomingPaymentHeader, IncomingPaymentHeaderDTO>().ReverseMap();
            CreateMap<IncomingPaymentInvoices, IncomingPaymentInvoicesDTO>().ReverseMap();
            CreateMap<IncomingPaymentChecks, IncomingPaymentChecksDTO>().ReverseMap();
            CreateMap<IncomingPaymentCreditCard, IncomingPaymentCreditCardDTO>().ReverseMap();
            #endregion
        }
    }
}
