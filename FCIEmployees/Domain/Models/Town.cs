
namespace Domain.Models
{
    public class Town: BaseEntity
        {
            public Guid TownID { get; set; } // GUID
            public string Name { get; set; }
            // علاقات
            public virtual ICollection<Address> Addresses { get; set; }
        }
}
