using Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class UserTaskEntity
    {
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }
        
        public string FileName { get; set; }
        
        public RatingEnum Rating { get; set; }
        
        public string AiRecommendation { get; set; }
        
        public string TutorRecommendation { get; set; }
        
        public bool IsCompleted { get; set; }
    }
}
