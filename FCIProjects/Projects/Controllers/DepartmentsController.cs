

namespace FciLuxor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator; // استخدام Mediator
        }

        // Create Department
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // Get Department by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdRequest { DepartmentID = id });
            return Ok(result);
        }

        // Get All Departments
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var result = await _mediator.Send(new GetAllDepartmentsRequest());
                return Ok(result);
            }
            catch (Exception ex)
            {
                // يمكنك استخدام ILogger لتسجيل الخطأ
                // Log.Error(ex, "An error occurred while fetching all departments.");
                return StatusCode(500, $"Controller Internal server error: {ex.Message}");
            }
        }

        // Update Department
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        // Delete Department
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            await _mediator.Send(new DeleteDepartmentRequest { DepartmentID = id });
            return NoContent();
        }
    }
}
