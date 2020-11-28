using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class DialogEntity : AutoincrementEntity
    {
        [Required]
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        public bool IsUserMessage { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
