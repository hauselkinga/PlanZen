namespace PlanZen.API.DbContexts
{
    public class PlanZenContext : DbContext
    {
        public DbSet<Table> Tables { get; set; } = null!;
        public DbSet<Column> Columns { get; set; } = null!;
        public DbSet<Card> Cards { get; set; } = null!;

        public PlanZenContext(DbContextOptions<PlanZenContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().HasData(
                new Table("Pet Project")
                {
                    Id = 1
                },
                new Table("Todos")
                {
                    Id = 2
                });

            modelBuilder.Entity<Column>().HasData(
                new Column("ToDo")
                {
                    Id = 1,
                    TableId = 1

                },
                new Column("InProgress")
                {
                    Id = 2,
                    TableId = 1
                },
                new Column("Todos")
                {
                    Id = 3,
                    TableId = 2
                },
                new Column("Done")
                {
                    Id = 4,
                    TableId = 2
                });

            modelBuilder.Entity<Card>().HasData(
                new Card("Implement Project")
                {
                    Id = 1,
                    Description = "Implement... Implement everything",
                    ColumnId = 1
                },
                new Card("Plan Project")
                {
                    Id = 2,
                    ColumnId = 2
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
