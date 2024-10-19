
namespace Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentRequest : IRequest<Unit>
    {
        public Guid DepartmentID { get; set; } // GUID
        public string DepartmentName { get; set; }
        public Guid ManagerID { get; set; }
    }
}
