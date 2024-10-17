

namespace Application.Features.Towns.Commands.DeleteTown
{
    public class DeleteTownHandler : IRequestHandler<DeleteTownRequest, Unit>
    {
        private readonly IGenericRepository<Town> _townRepository;
        private readonly IGenericRepository<Address> _addressRepository;
        private readonly EmployeesDbContext _context; // إضافة DbContext

        public DeleteTownHandler(IGenericRepository<Town> townRepository, IGenericRepository<Address> addressRepository, EmployeesDbContext context)
        {
            _townRepository = townRepository;
            _addressRepository=addressRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(DeleteTownRequest request, CancellationToken cancellationToken)
        {
            var town = await _townRepository.GetByIdAsync(request.TownID);
            if (town == null)
            {
                throw new KeyNotFoundException($"Town with ID {request.TownID} not found.");
            }
            // تحقق مما إذا كانت المدينة مرتبطة بعناوين
            var addresses = await _addressRepository.GetAllAsync(a => a.TownID == request.TownID);
            if (addresses.Any())
            {
                throw new InvalidOperationException($"Cannot delete town with ID {request.TownID} because it has associated addresses.");
            }

            
            await _townRepository.DeleteAsync(town.TownID);
            await _context.SaveChangesAsync(); // استخدم DbContext لحفظ التغييرات
           

            return Unit.Value;
        }
    }
}
