

namespace FciLuxor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ProjectsDbContext _projectsDbContext; // إضافة DbContext

        public ProjectsController(IMediator mediator, ProjectsDbContext projectsDbContext)
        {
            _mediator = mediator; // استخدام Mediator
            _projectsDbContext = projectsDbContext; // تمرير DbContext
        }

        // نقطة النهاية لاختبار الوصول إلى DbContext
        [HttpGet("test-db")]
        public IActionResult TestDatabaseConnection()
        {
            try
            {
                var projects = _projectsDbContext.Set<Project>().ToList(); // استرجاع جميع 
                return Ok(projects); // إرجاع قائمة 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); // إرجاع خطأ 500 في حالة حدوث استثناء
            }
        }

        // Create Project
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // Get Project by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var result = await _mediator.Send(new GetProjectByIdRequest { ProjectID = id });
            return Ok(result);
        }

        // Get All Projects
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                var result = await _mediator.Send(new GetAllProjectsRequest());
                return Ok(result);
            }
            catch (Exception ex)
            {
                // يمكنك استخدام ILogger لتسجيل الخطأ
                // Log.Error(ex, "An error occurred while fetching all projects.");
                return StatusCode(500, $"Controller Internal server error: {ex.Message}");
            }
        }

        // Update Project
        [HttpPut]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        // Delete Project
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _mediator.Send(new DeleteProjectRequest { ProjectID = id });
            return NoContent();
        }
    }
}
