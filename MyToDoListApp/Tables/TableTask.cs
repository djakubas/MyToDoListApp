using System.ComponentModel.DataAnnotations;

namespace MyToDoListApp.Tables
{
    public class TableTask
    {
        [Key]
        public int TaskId { get; set; }
        public required string Title { get; set; }
        public string? Status { get; set; } = "ToDo";
        public string? AssignedTo { get; set; } = null;
        public DateTime CreationDate { get; set; } = DateTime.Today;
        public DateTime LastUpdateDate { get; set; } = DateTime.Today;
        public string? Description { get; set; }
        public DateOnly? DueDate { get; set; }
    }
}
