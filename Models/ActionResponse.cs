namespace ProductManagement_APIDashboard.Models
{
    public class ActionResponse
    {
        public bool Success { get; set; }
        public Error? Error { get; set; }
    }
    public class Error
    {
        public string? Message { get; set; }
    }

}
