using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenantsApi.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PropertyName { get; set; }
        public string Address { get; set; }
        public string RentDueDate { get; set; }
        public double RentAmount { get; set; }
    }
}
