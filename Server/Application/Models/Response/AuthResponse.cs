namespace Application.Models.Response
{
    public class AuthResponse
    {
        public bool IsSuccessful { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
        public List<string>? Errors { get; set; }
    }
}
