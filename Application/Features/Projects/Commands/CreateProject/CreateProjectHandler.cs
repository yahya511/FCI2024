
namespace Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectRequest, Unit>
    {
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly ProjectsDbContext _context; // إضافة DbContext

        public CreateProjectHandler(IGenericRepository<Project> projectRepository, ProjectsDbContext context)
        {
            _projectRepository = projectRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(CreateProjectRequest request, CancellationToken cancellationToken)
        {
            var newProject = new Project
            {
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            await _projectRepository.AddAsync(newProject);
            await _context.SaveChangesAsync(); // استخدم DbContext لحفظ التغييرات

            return Unit.Value; // إرجاع وحدة القيمة لتشير إلى النجاح
        }
    }
}
