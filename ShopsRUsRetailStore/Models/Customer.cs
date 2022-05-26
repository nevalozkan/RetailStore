using ShopsRUsRetailStore.API.Models.Enums;

namespace ShopsRUsRetailStore.API.Models
{
    public class Customer
    {
        public CustomerTypes Type { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
