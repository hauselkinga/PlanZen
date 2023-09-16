namespace PlanZen.API.Entities
{
    public class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public ICollection<Column> Columns { get; set; } = new List<Column>();

        public Table(string title)
        {
            Title = title;
        }
    }
}
