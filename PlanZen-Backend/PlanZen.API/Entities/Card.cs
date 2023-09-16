namespace PlanZen.API.Entities
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DueDate { get; set; }

        [ForeignKey("ColumnId")]
        public Column? Column { get; set; }
        public int ColumnId { get; set; }

        public Card(string title)
        {
            Title = title;
        }
    }
}
