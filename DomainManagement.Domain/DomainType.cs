using DomainManagement.Domain.Common;

namespace DomainManagement.Domain
{
    // This class represents a specific domain type within the application and 
    // extends BaseEntity to inherit common entity properties like Id, DateCreated, and DateModified.
    public class DomainType : BaseEntity
    {
        // The 'DomainName' property holds the name of the domain. 
        // It is initialized to an empty string to avoid null reference issues.
        public string DomainName { get; set; } = string.Empty;

        // The 'OwnerName' property stores the name of the domain's owner. 
        // It is also initialized to an empty string to prevent null reference issues.
        public string OwnerName { get; set; } = string.Empty;

        // The 'Ip' property holds the IP address associated with the domain. 
        // It is initialized to an empty string to ensure that it has a default value.
        public string Ip { get; set; } = string.Empty;
    }
}
