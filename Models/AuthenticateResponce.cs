namespace ProductManagement_APIDashboard.Models
{
    public class AuthenticateResponce
    {
        public bool Success { get;set; }
        public string? Token {  get;set; }
        public string? Message { get;set; }
    }
    
}
