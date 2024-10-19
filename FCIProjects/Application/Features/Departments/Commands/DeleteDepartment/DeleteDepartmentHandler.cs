namespace Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDepartmentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(request.DepartmentID);
            if (department == null)
            {
                throw new KeyNotFoundException($"Department with ID {request.DepartmentID} not found.");
            }

            /* // تحقق مما إذا كانت المدينة مرتبطة بعناوين
            var employeesDepartments = await _unitOfWork.employeeDepartment.GetAllAsync(em => em.DepartmentID == request.DepartmentID);
            if (employeesDepartments.Any())
            {
                throw new InvalidOperationException($"Cannot delete Department with ID {request.DepartmentID} because it has associated employeesDepartments.");
            } */

            // حذف المشروع
            await _unitOfWork.Departments.DeleteAsync(department.DepartmentID);

            // حفظ جميع التغييرات باستخدام UnitOfWork
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
