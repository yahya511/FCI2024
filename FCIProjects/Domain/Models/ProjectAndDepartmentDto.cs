namespace Domain.Models 
{
    public class ProjectAndDepartmentDto
    {
        // حقول إنشاء المشروع
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // حقول إنشاء القسم
        public string DepartmentName { get; set; }
        public Guid ManagerID { get; set; }
    }
}
