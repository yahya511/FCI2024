

namespace Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectRequest, Unit>
    {
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly IGenericRepository<EmployeesProjects> _employeesProjectsRepository;
        private readonly ProjectsDbContext _context; // إضافة DbContext

        public DeleteProjectHandler(IGenericRepository<Project> projectRepository,IGenericRepository<EmployeesProjects> employeesProjectsRepository,  ProjectsDbContext context)
        {
            _projectRepository = projectRepository;
            _employeesProjectsRepository=employeesProjectsRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectID);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {request.ProjectID} not found.");
            }
            // تحقق مما إذا كانت المدينة مرتبطة بعناوين
            var employeesProjects = await _employeesProjectsRepository.GetAllAsync(em => em.ProjectID == request.ProjectID);
            if (employeesProjects.Any())
            {
                throw new InvalidOperationException($"Cannot delete Project with ID {request.ProjectID} because it has associated employeesProjects.");
            }

            
            await _projectRepository.DeleteAsync(project.ProjectID);
            await _context.SaveChangesAsync(); // استخدم DbContext لحفظ التغييرات
           

            return Unit.Value;
        }
    }
}
