namespace Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdRequest : IRequest<Department>
    {
        public Guid DepartmentID { get; set; }
    }
}