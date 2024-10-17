
namespace Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectRequest, Unit>
    {
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly ProjectsDbContext _context; // إضافة DbContext

        public UpdateProjectHandler(IGenericRepository<Project> projectRepository, ProjectsDbContext context)
        {
            _projectRepository = projectRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectID);

            if (project == null)
            {
                throw new Exception("Project not found."); // يمكنك تخصيص استثناء أفضل حسب الحاجة
            }

            // تحديث الخصائص المطلوبة
            project.Name = request.Name;
            project.Description = request.Description;
            project.StartDate = request.StartDate;
            project.EndDate = request.EndDate;

            await _projectRepository.UpdateAsync(project);
            await _context.SaveChangesAsync(); // استخدم DbContext لحفظ التغييرات

            return Unit.Value; // إرجاع وحدة القيمة لتشير إلى النجاح
        }
    }
}
