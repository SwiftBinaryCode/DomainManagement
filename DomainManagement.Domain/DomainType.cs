using DomainManagement.Domain.Common;

namespace DomainManagement.Domain
{
    public class DomainType : BaseEntity
    {
        public string DomainName { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;

        public string Ip { get; set; } = string.Empty;
    }
}
