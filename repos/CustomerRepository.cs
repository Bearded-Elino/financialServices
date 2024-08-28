using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.data;
using FinancialServices.dtos.customerDto;
using FinancialServices.interfaces.ICustomerRepo;
using FinancialServices.mappers.customer;
using FinancialServices.models.customerModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinancialServices.repos
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> CreateCustomerAsync(CustomerDto customerDto)
        {
            try
            {
                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Email = customerDto.Email,
                    Phone = customerDto.Phone,
                };
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> DeleteByIdAsync(Guid Id)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Id == Id);
                if (customer == null)
                {
                    return null;
                }
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                
                throw new Exception("cannot delete customer", ex);
            }
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                return customers;
            }
            catch (Exception ex)
            {
                
                throw new Exception("bad request. cannot show customers", ex);
            }
        }

        public Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
                if (customer == null)
                {
                    return null;
                }
                return customer;
            }
            catch (Exception ex)
            {
                
                throw new Exception("bad requst. Try again", ex);
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Guid customerId, CustomerDto customerDto)
        {
            try
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
                if(customer == null)
                {
                    return null;
                }
                
                customer.FirstName = customerDto.FirstName;
                customer.LastName = customerDto.LastName;
                customer.Email = customerDto.Email;
                customer.Phone = customerDto.Phone;

                await _context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                
                throw new Exception("cannot create new customer", ex);
            }
        }

        public bool UpgradeAccountAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}