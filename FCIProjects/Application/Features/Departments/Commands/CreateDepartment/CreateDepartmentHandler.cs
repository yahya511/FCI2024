
namespace Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDepartmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var newDepartment = new Department
            {
                DepartmentName = request.DepartmentName,
                ManagerID = request.ManagerID
            };

            await _unitOfWork.Departments.AddAsync(newDepartment);
            await _unitOfWork.CommitAsync(); // استخدم DbContext لحفظ التغييرات

            return Unit.Value; // إرجاع وحدة القيمة لتشير إلى النجاح
        }

    }
}
