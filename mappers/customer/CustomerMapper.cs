using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.dtos.customerDto;
using FinancialServices.models.customerModel;

namespace FinancialServices.mappers.customer
{
    public static class CustomerMapper
    {
        public static Customer ToModelFromCustomerDto(this CustomerDto customerDto)
        {
            return new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
            };
        }

        public static CustomerDto ToCustomerDtoFromModel(this Customer customer)
        {
            return new CustomerDto
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
            };
        }
    }
}