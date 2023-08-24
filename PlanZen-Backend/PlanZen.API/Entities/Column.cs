namespace PlanZen.API.Entities
{
    public class Column
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public ICollection<Card> Cards { get; set;} = new List<Card>();

        [ForeignKey("TableId")]
        public Table? Table { get; set; }
        public int TableId { get; set; }

        public Column(string title)
        {
            Title = title;
        }
    }
}
