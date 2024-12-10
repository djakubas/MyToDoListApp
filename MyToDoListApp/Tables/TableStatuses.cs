using System.ComponentModel.DataAnnotations;

namespace MyToDoListApp.Tables
{
    public class TableStatuses
    {
        [Key]
        public required string Status { get; set; }
    }
}
