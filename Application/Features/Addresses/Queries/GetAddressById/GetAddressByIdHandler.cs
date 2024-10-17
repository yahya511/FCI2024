

namespace Application.Features.Addresses.Queries.GetAddressById
{
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdRequest, Address>
    {
        private readonly IGenericRepository<Address> _addressRepository;

        public GetAddressByIdHandler(IGenericRepository<Address> addressRepository)
        {
            _addressRepository=addressRepository;
        }

        public async Task<Address> Handle(GetAddressByIdRequest request, CancellationToken cancellationToken)
        {
            return await _addressRepository.GetByIdAsync(request.AddressID);
        }
    }
}