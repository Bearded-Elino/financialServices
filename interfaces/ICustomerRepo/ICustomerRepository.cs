using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.data;
using FinancialServices.dtos.customerDto;
using FinancialServices.models.customerModel;

namespace FinancialServices.interfaces.ICustomerRepo
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetCustomerByIdAsync(Guid customerId);
        public Task<List<Customer>> GetAllCustomersAsync();
        public Task<Customer> CreateCustomerAsync(CustomerDto customerDto);
        public Task<Customer> UpdateCustomerAsync(Guid customerId, CustomerDto customerDto);
        public Task<Customer> DeleteByIdAsync(Guid Id);
        public bool UpgradeAccountAsync(Guid Id);

    }
}