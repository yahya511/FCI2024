
namespace Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressRequest : IRequest<Unit>
    {
        public Guid AddressID { get; set; } // GUID
        public string AddressText { get; set; }
        public Guid? TownID { get; set; }
    }
}
