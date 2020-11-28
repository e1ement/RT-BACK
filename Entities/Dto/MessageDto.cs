using Entities.Enums;
using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dto
{
    public class MessageDto
    {
        [Required]
        public MessageSender Sender { get; set; }
        
        [Required]
        public string Message { get; set; }

        public DialogEntity ToEntity(int userId, int taskId)
        {
            return new DialogEntity
            {
                UserId = userId,
                TaskId = taskId,
                IsUserMessage = Sender == MessageSender.User,
                Message = Message
            };
        }
    }
}
