using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialServices.dtos.customerDto
{
    public class CustomerDto
    {
        public string FirstName { get; set;}=string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set;}=string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set;}=string.Empty;
        [Required]
        [MaxLength(15)]
        public string Phone { get; set;}=string.Empty;
    }
}