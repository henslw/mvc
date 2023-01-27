namespace ContosoUniversity.Models
{
    public class ErrorViewModel
    {
        // removed nullable tag from string? for compliance with EF
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}