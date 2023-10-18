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
    // This class implements the IUserService interface and provides the methods to handle user-related operations.
    public class UserService : IUserService
    {
        // A private field to hold the reference to UserManager for accessing user store.
        private readonly UserManager<ApplicationUser> _userManager;

        // Constructor that takes UserManager as a dependency and initializes the private UserManager field.
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // Asynchronous method to retrieve a specific customer's details using the user ID.
        // The method returns a Customer object containing user information.
        public async Task<Customer> GetCustomer(string userId)
        {
            // Fetches the user by their ID from the user store.
            var customer = await _userManager.FindByIdAsync(userId);

            // Maps the ApplicationUser object to a Customer object and returns it.
            return new Customer
            {
                Email = customer.Email,
                Id = customer.Id,
                Firstname = customer.FirstName,
                Lastname = customer.LastName
            };
        }

        // Asynchronous method to retrieve a list of all customers.
        // The method returns a list of Customer objects containing information of all users with the 'Customer' role.
        public async Task<List<Customer>> GetCustomers()
        {
            // Fetches users with the 'Customer' role from the user store.
            var customers = await _userManager.GetUsersInRoleAsync("Customer");

            // Maps the collection of ApplicationUser objects to a list of Customer objects and returns it.
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
