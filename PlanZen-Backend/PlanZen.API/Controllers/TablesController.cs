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
        public async Task<ActionResult<List<Table>>> GetTables()
        {
            return Ok(await _tablesRepository.GetTables());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _tablesRepository.GetTableById(id);

            if (table == null)
            {
                return NotFound();
            }

            return Ok(table);
        }
    }
}
