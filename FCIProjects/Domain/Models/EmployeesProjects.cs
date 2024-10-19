namespace Domain.Models
{
    public class EmployeesProjects : BaseEntity
    {
        public Guid EmployeeID { get; set; }
        public Guid ProjectID { get; set; }

         
    }
}
