namespace PlanZen.API.Repositories
{
    public class TablesRepository : ITablesRepository
    {
        private readonly PlanZenContext _context;
        public TablesRepository(PlanZenContext context)
        {
            _context = context;
        }

        public Task<List<Table>> GetTables()
        {
            return _context.Tables
                .Include(t => t.Columns)
                .ToListAsync();
        }
        public Task<Table?> GetTableById(int tableId)
        {
            var table = _context.Tables
                .Include(t => t.Columns)
                .FirstOrDefaultAsync(t => t.Id == tableId);
            return table;
        }

    }
}
