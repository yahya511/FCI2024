
namespace Domain.Models
{
    public class Address : BaseEntity
    {
        public Guid AddressID { get; set; } // GUID
        public string AddressText { get; set; }
        public Guid? TownID { get; set; }

        // علاقات
        public virtual Town Town { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

}
