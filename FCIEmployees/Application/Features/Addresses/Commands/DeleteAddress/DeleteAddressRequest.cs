
namespace Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressRequest : IRequest
    {
        public Guid AddressID { get; set; }
    }
}
