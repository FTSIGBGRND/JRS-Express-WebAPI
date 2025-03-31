namespace FTSI_Web_API_System_Integration.DTOs
{
    public class ErrorStatusDTO
    {
        public string? Status { get; set; } = "0";

        public ErrorDetails? ErrorDetails { get; set; }
    }

    public class ErrorDetails
    {
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
