
namespace Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectRequest : IRequest
    {
        public Guid ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
