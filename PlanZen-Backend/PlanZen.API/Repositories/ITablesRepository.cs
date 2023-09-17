namespace PlanZen.API.Repositories
{
    public interface ITablesRepository
    {
        public Task<List<Table>> GetTables();
        public Task<Table?> GetTableById(int tableId);
        public Task AddTable(Table table);
        public Task SaveAsync();
        public void DeleteTable(Table table);
    }
}
