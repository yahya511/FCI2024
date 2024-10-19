
namespace Domain.Models
{
    public class Project : BaseEntity
    {
        public Guid ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

         
    }
}
