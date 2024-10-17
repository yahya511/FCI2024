

namespace FciLuxor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly EmployeesDbContext _employeesDbContext; // إضافة DbContext

        public AddressesController(IMediator mediator, EmployeesDbContext employeesDbContext)
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
                var addresses = _employeesDbContext.Set<Address>().ToList(); // استرجاع جميع 
                return Ok(addresses); // إرجاع قائمة 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // إرجاع خطأ 500 في حالة حدوث استثناء
            }
        }

        // Create Town
        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // Get Town by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(Guid id)
        {
            var result = await _mediator.Send(new GetAddressByIdRequest { AddressID = id });
            return Ok(result);
        }

        // Get All Towns
        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            try
            {
                var result = await _mediator.Send(new GetAllAddressesRequest());
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
        public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        // Delete Town
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            await _mediator.Send(new DeleteAddressRequest { AddressID = id });
            return NoContent();
        }
    }
}
