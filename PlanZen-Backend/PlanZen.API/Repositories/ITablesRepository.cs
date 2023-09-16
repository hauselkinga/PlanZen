namespace PlanZen.API.Repositories
{
    public interface ITablesRepository
    {
        public Task<List<Table>> GetTables();
    }
}
