using Infrastructure.DbContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FciLuxor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TownsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly EmployeesDbContext _employeesDbContext; // إضافة DbContext

        public TownsController(IMediator mediator, EmployeesDbContext employeesDbContext)
        {
            _mediator = mediator; // استخدام Mediator
            _employeesDbContext = employeesDbContext; // تمرير DbContext
        }

        // نقطة النهاية لاختبار الوصول إلى DbContext
        [HttpGet("test-db")]
        public IActionResult TestDatabaseConnection()
        {
            try
            {
                var towns = _employeesDbContext.Set<Town>().ToList(); // استرجاع جميع المدن
                return Ok(towns); // إرجاع قائمة المدن
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // إرجاع خطأ 500 في حالة حدوث استثناء
            }
        }

        // Create Town
        [HttpPost]
        public async Task<IActionResult> CreateTown([FromBody] CreateTownRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // Get Town by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTownById(Guid id)
        {
            var result = await _mediator.Send(new GetTownByIdRequest { TownID = id });
            return Ok(result);
        }

        // Get All Towns
        [HttpGet]
        public async Task<IActionResult> GetAllTowns()
        {
            try
            {
                var result = await _mediator.Send(new GetAllTownsRequest());
                return Ok(result);
            }
            catch (Exception ex)
            {
                // يمكنك استخدام ILogger لتسجيل الخطأ
                // Log.Error(ex, "An error occurred while fetching all towns.");
                return StatusCode(500, $"Controller Internal server error: {ex.Message}");
            }
        }

        // Update Town
        [HttpPut]
        public async Task<IActionResult> UpdateTown([FromBody] UpdateTownRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        // Delete Town
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTown(Guid id)
        {
            await _mediator.Send(new DeleteTownRequest { TownID = id });
            return NoContent();
        }
    }
}
