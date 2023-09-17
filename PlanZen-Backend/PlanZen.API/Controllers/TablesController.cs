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

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Table>> UpdateTableTitle(int id, Table table)
        {
            var tableToUpdate = await _tablesRepository.GetTableById(id);

            if (tableToUpdate == null)
            {
                return NotFound();
            }

            tableToUpdate.Title = table.Title;
            _tablesRepository.UpdateTable(tableToUpdate);
            await _tablesRepository.SaveAsync();
            return Ok(tableToUpdate);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteTable(int id)
        {
            var tableToDelete = await _tablesRepository.GetTableById(id);

            if (tableToDelete == null)
            {
                return NotFound();
            }

            _tablesRepository.DeleteTable(tableToDelete);
            await _tablesRepository.SaveAsync();
            return NoContent();
        }
    }
}
