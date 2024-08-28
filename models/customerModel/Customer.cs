using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinancialServices.models.customerModel
{
     [Index("Email", IsUnique = true)]
     [Index("Phone", IsUnique =true)]
     

    public class Customer
    {
        [Key]
        public Guid Id { get; set;}
        [Required]
        [MaxLength(50)]
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
        public int Tier { get; set;}=1;
        public DateTime CreatedOn { get; set;}=DateTime.Now;
        public DateTime LastUpdatedOn { get; set;}=DateTime.Now;

    }
}