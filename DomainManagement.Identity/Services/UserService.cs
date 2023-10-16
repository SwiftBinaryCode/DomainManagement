using DomainManagement.Application.Contracts.Identity;
using DomainManagement.Application.Models.Identity;
using DomainManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Customer> GetCustomer(string userId)
        {
            var customer = await _userManager.FindByIdAsync(userId);
            return new Customer
            {
                Email = customer.Email,
                Id = customer.Id,
                Firstname = customer.FirstName,
                Lastname = customer.LastName
            };
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _userManager.GetUsersInRoleAsync("Customer");
            return customers.Select(q => new Customer
            {
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName
            }).ToList();
        }
    }
}
