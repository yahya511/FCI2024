
namespace Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressRequest, Unit>
    {
        private readonly IGenericRepository<Address> _addressRepository;
        private readonly IGenericRepository<Town> _townRepository;

        private readonly EmployeesDbContext _context; // إضافة DbContext

        public CreateAddressHandler(IGenericRepository<Address> addressRepository,IGenericRepository<Town> townRepository, EmployeesDbContext context)
        {
            _addressRepository = addressRepository;
            _townRepository=townRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
        {
             // التحقق من أن TownID يشير إلى مدينة موجودة
            if (request.TownID.HasValue)
            {
                var townExists = await _townRepository.GetByIdAsync(request.TownID.Value);
                if (townExists == null)
                {
                    throw new KeyNotFoundException($"Town with ID {request.TownID.Value} not found.");
                }
            }
            var newAddress = new Address
            {
                AddressText = request.AddressText,
                TownID = request.TownID
            };

            await _addressRepository.AddAsync(newAddress);
            await _context.SaveChangesAsync(); // استخدم DbContext لحفظ التغييرات

            return Unit.Value; // إرجاع وحدة القيمة لتشير إلى النجاح
        }

       
    }
}
