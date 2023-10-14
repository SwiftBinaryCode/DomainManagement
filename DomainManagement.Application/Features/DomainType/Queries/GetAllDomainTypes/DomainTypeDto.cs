using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes
{
    public class DomainTypeDto
    {
        public string DomainName { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;

        public int Ip { get; set; }
    }
}
