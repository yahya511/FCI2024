
namespace Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentRequest : IRequest<Unit>
    {
        public string DepartmentName { get; set; }
        public Guid ManagerID { get; set; }
    }
}


