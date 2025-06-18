namespace FastypeService.Models.DTOs
{
    public class SignupResponseDto
    {
        public Guid? Id { get; set; }
        public bool Success { get; set; }
        public List<string> Message { get; set; }
    }
}
