
namespace Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressRequest : IRequest<Unit>
    {
        public Guid AddressID { get; set; } // GUID
        public string AddressText { get; set; }
        public Guid? TownID { get; set; }    
    }
}


