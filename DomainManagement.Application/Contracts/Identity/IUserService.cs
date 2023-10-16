using DomainManagement.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomer(string userId);
    }
}
