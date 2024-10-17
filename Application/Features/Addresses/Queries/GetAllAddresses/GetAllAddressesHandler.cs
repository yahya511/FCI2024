
namespace Application.Features.Addresses.Queries.GetAllAddresses
{
    public class GetAllAddressesHandeler : IRequestHandler<GetAllAddressesRequest, IEnumerable<Address>>
    {   
        private readonly IGenericRepository<Address> _addressRepository;

        public GetAllAddressesHandeler(IGenericRepository<Address> addressRepository)
        {
            _addressRepository=addressRepository;
        }



        public async Task<IEnumerable<Address>> Handle(GetAllAddressesRequest request, CancellationToken cancellationToken)
        {
            return await _addressRepository.GetAllAsync();
        }
    }
}