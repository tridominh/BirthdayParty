namespace BirthdayParty.Models.DTOs
{
    public class ServiceCreateDto
    {
        public int PackageId { get; set; }
        public string ServiceName { get; set; } = null!;
    }
}
