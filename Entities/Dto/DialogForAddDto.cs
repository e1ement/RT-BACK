using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dto
{
    public class DialogForAddDto
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int TaskId { get; set; }
        
        [Required]
        public bool IsUserMessage { get; set; }
        
        [Required]
        public string Message { get; set; }

        public DialogEntity ToEntity()
        {
            return new DialogEntity
            {
                UserId = UserId,
                TaskId = TaskId,
                IsUserMessage = IsUserMessage,
                Message = Message
            };
        }
    }
}
