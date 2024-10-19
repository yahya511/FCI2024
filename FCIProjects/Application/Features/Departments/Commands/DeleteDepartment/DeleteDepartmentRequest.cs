
namespace Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentRequest : IRequest
    {
        public Guid DepartmentID { get; set; } // GUID
        public string DepartmentName { get; set; }
        public Guid ManagerID { get; set; }
    }
}
