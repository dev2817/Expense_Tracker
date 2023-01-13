using System.ComponentModel.DataAnnotations;

namespace expense_tracker.Models
{
    public class Global
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Value { get; set; }
    }
}
