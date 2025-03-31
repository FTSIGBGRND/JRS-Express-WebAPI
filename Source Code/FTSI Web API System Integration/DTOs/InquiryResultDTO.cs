namespace FTSI_Web_API_System_Integration.DTOs
{
    public class InquiryResultDTO
    {
        public string? Status { get; set; }

        public InquiryResultData? Data { get; set; }
    }

    public class InquiryResultData
    {
        public string? SubmitId { get; set; }

        public int? TotalCountQty { get; set; }

        public List<ProcessDocument>? ProcessDocuments { get; set; }
    }

    public class ProcessDocument
    {
        public Guid? Id { get; set; }
        public string? U_RefNum { get; set; }

        public char? IntegrationStatus { get; set; }
        public string? IntegrationMessage { get; set; }
    }
}
