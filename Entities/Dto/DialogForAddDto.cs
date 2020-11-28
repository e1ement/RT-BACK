using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dto
{
    public class DialogForAddDto
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public int TaskId { get; set; }

        public List<MessageDto> Messages { get; set; }
    }
}
