namespace FTSI_Web_API_System_Integration.DTOs
{
    public class SuccessStatusDTO
    {
        public string? Status { get; set; } = "1";

        public List<PostedData>? Data { get; set; }
    }

    public class PostedData
    {
        public Guid Id { get; set; }
        public string? U_RefNum { get; set; }
    }
}
