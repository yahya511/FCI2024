
namespace Application.Features.Towns.Commands.UpdateTown
{
    public class UpdateTownRequest : IRequest<Unit>
    {
        public Guid TownID { get; set; }
        public string Name { get; set; }
    }
}
