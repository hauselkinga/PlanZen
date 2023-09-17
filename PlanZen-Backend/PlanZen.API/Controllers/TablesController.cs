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

        [HttpGet("{id}", Name = "GetTable")]
        public async Task<ActionResult<Table>> GetTable(int id)
        {
            var table = await _tablesRepository.GetTableById(id);

            if (table == null)
            {
                return NotFound();
            }

            return Ok(table);
        }

        [HttpPost]
        public async Task<ActionResult<Table>> CreateTable(Table table)
        {
            await _tablesRepository.AddTable(table);
            await _tablesRepository.SaveAsync();
            return CreatedAtAction("GetTable", new { id = table.Id }, table);
        }
    }
}
