using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenantsApi.Models
{
    public class Maintenance
    {
        public int Id { get; set; }
        public string SelectedRoom { get; set; }
        public string Issue { get; set; }
        public string Description { get; set; }
        public string SelectedArea { get; set; }
        public string Email { get; set; }
    }
}
