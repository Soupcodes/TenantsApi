//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

namespace TenantsApi.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        //[Required]
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public double RentAmount { get; set; }
        public string Address { get; set; }
        public string TenancyExpires { get; set; }
    }
}