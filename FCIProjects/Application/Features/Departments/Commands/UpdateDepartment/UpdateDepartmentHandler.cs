
namespace Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDepartmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(request.DepartmentID);

            if (department == null)
            {
                throw new Exception("Department not found."); // يمكنك تخصيص استثناء أفضل حسب الحاجة
            }

            // تحديث الخصائص المطلوبة
            department.DepartmentName= request.DepartmentName;
            department.ManagerID = request.ManagerID;
           

            await _unitOfWork.Departments.UpdateAsync(department);
            await _unitOfWork.CommitAsync(); // استخدم DbContext لحفظ التغييرات

            return Unit.Value; // إرجاع وحدة القيمة لتشير إلى النجاح
        }
    }
}
