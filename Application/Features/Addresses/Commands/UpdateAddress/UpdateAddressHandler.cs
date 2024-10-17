
namespace Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressRequest, Unit>
    {
        private readonly IGenericRepository<Address> _addressRepository;
        private readonly IGenericRepository<Town> _townRepository;
        private readonly EmployeesDbContext _context; // إضافة DbContext

        public UpdateAddressHandler(IGenericRepository<Address> addressRepository,IGenericRepository<Town> townRepository, EmployeesDbContext context)
        {
            _addressRepository = addressRepository;
            _townRepository=townRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            var Address = await _addressRepository.GetByIdAsync(request.AddressID);

            if (Address == null)
            {
                throw new Exception("Address not found."); // يمكنك تخصيص استثناء أفضل حسب الحاجة
            }

            // التحقق من أن TownID يشير إلى مدينة موجودة
            if (request.TownID.HasValue)
            {
                var townExists = await _townRepository.GetByIdAsync(request.TownID.Value);
                if (townExists == null)
                {
                    throw new KeyNotFoundException($"Town with ID {request.TownID.Value} not found.");
                }
            }

            // تحديث الخصائص المطلوبة
            
             Address.AddressText=request.AddressText;
             Address.TownID=request.TownID;

            await _addressRepository.UpdateAsync(Address);
            await _context.SaveChangesAsync(); // استخدم DbContext لحفظ التغييرات

            return Unit.Value; // إرجاع وحدة القيمة لتشير إلى النجاح
        }

    }
}
