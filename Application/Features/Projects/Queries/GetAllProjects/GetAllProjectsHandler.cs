
namespace Application.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsRequest, IEnumerable<Project>>
    {
        private readonly IGenericRepository<Project> _projectRepository;

        public GetAllProjectsHandler(IGenericRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> Handle(GetAllProjectsRequest request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetAllAsync();
        }
    }
}
