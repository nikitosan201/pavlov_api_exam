using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi.Models
{
    public class TaskCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [RegularExpression("Pending|Done", ErrorMessage = "Status must be 'Pending' or 'Done'.")]
        public string Status { get; set; } = "Pending";
    }
}
