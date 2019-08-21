namespace TenantsApi.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public double Rent { get; set; }
        public string Address { get; set; }
    }
}