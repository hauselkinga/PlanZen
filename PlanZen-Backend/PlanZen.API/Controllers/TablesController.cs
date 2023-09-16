namespace PlanZen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITablesRepository _tablesRepository;
        public TablesController(ITablesRepository tablesRepository)
        {
            _tablesRepository = tablesRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetTables()
        {
            return Ok(await _tablesRepository.GetTables());
        }
    }
}
