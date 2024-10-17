

namespace Application.Features.Projects.Queries.GetProjectById
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdRequest, Project>
    {
        private readonly IGenericRepository<Project> _projectRepository;

        public GetProjectByIdHandler(IGenericRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetByIdAsync(request.ProjectID);
        }
    }

}
