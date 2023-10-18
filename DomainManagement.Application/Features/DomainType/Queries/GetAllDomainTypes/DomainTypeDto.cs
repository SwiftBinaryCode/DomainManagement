namespace DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes
{
    public class DomainTypeDto
    {
        public int Id { get; set; }
        public string DomainName { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;

        public string Ip { get; set; }
    }
}
