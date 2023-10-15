using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Features.DomainType.Queries.GetDomainTypeDetails
{
    public class DomainTypeDetailsDto
    {
        public int Id { get; set; }
        public string DomainName { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;

        public string Ip { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }


    }
}
