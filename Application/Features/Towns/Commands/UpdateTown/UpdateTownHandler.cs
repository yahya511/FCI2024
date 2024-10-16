
namespace Application.Features.Towns.Commands.UpdateTown
{
    public class UpdateTownHandler : IRequestHandler<UpdateTownRequest, Unit>
    {
        private readonly IGenericRepository<Town> _townRepository;
        private readonly EmployeesDbContext _context; // إضافة DbContext

        public UpdateTownHandler(IGenericRepository<Town> townRepository, EmployeesDbContext context)
        {
            _townRepository = townRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(UpdateTownRequest request, CancellationToken cancellationToken)
        {
            var town = await _townRepository.GetByIdAsync(request.TownID);

            if (town == null)
            {
                throw new Exception("Town not found."); // يمكنك تخصيص استثناء أفضل حسب الحاجة
            }

            // تحديث الخصائص المطلوبة
            town.Name = request.Name; // افترض أن لديك خاصية اسمية

            await _townRepository.UpdateAsync(town);
            await _context.SaveChangesAsync(); // استخدم DbContext لحفظ التغييرات

            return Unit.Value; // إرجاع وحدة القيمة لتشير إلى النجاح
        }
    }
}
