

namespace Application.Features.Towns.Commands.DeleteTown
{
    public class DeleteTownHandler : IRequestHandler<DeleteTownRequest, Unit>
    {
        private readonly IGenericRepository<Town> _townRepository;
        private readonly EmployeesDbContext _context; // إضافة DbContext

        public DeleteTownHandler(IGenericRepository<Town> townRepository, EmployeesDbContext context)
        {
            _townRepository = townRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(DeleteTownRequest request, CancellationToken cancellationToken)
        {
            var town = await _townRepository.GetByIdAsync(request.TownID);

            if (town != null)
            {
                await _townRepository.DeleteAsync(town.TownID);
                await _context.SaveChangesAsync(); // استخدم DbContext لحفظ التغييرات
            }

            return Unit.Value;
        }
    }
}
