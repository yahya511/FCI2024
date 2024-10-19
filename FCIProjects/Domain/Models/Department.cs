namespace Domain.Models
{
    public class Department: BaseEntity
    {
        public Guid DepartmentID { get; set; } // GUID
        public string DepartmentName { get; set; }
        public Guid ManagerID { get; set; }

    }

}
