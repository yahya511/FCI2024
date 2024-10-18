
namespace Application.Features.Towns.Commands.DeleteTown
{
    public class DeleteTownRequest : IRequest
    {
        public Guid TownID { get; set; }
    }
}
