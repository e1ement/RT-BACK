using Entities.Common;
using Entities.Models;

namespace Entities.Dto
{
    public class DialogDto : AutoincrementObject
    {
        public bool IsUserMessage { get; set; }

        public string Message { get; set; }

        public DialogDto(DialogEntity entity) : base(entity)
        {
            if (entity == null)
            {
                return;
            }

            IsUserMessage = entity.IsUserMessage;
            Message = entity.Message;
        }
    }
}
