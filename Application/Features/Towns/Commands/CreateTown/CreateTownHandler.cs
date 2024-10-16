
namespace Application.Features.Towns.Commands.CreateTown
{
    public class CreateTownHandler : IRequestHandler<CreateTownRequest, Unit>
    {
        private readonly IGenericRepository<Town> _townRepository;
        private readonly EmployeesDbContext _context; // إضافة DbContext

        public CreateTownHandler(IGenericRepository<Town> townRepository, EmployeesDbContext context)
        {
            _townRepository = townRepository;
            _context = context; // تهيئة DbContext
        }

        public async Task<Unit> Handle(CreateTownRequest request, CancellationToken cancellationToken)
        {
            var newTown = new Town
            {
                Name = request.Name, // افترض أن لديك خاصية اسمية
                // إضافة أي خصائص أخرى لازمة
            };

            await _townRepository.AddAsync(newTown);
            await _context.SaveChangesAsync(); // استخدم DbContext لحفظ التغييرات

            return Unit.Value; // إرجاع وحدة القيمة لتشير إلى النجاح
        }
    }
}
