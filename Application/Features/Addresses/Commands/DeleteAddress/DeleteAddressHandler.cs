

namespace Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressRequest, Unit>
    {

        private readonly IGenericRepository<Address> _addressRepository;
        private readonly EmployeesDbContext _context; // إضافة DbContext

        public DeleteAddressHandler(IGenericRepository<Address> addressRepository, EmployeesDbContext context)
        {
            _addressRepository = addressRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
        {
            var Address=await _addressRepository.GetByIdAsync(request.AddressID);
            if(Address!=null)
            {
                await _addressRepository.DeleteAsync(Address.AddressID);
                await _context.SaveChangesAsync();

            }
            return Unit.Value;
        }
    }
}
