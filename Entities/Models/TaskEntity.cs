using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class TaskEntity : AutoincrementEntity
    {
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        
        [Required]
        public string TitleRu { get; set; }
        
        [Required]
        public string TitleEn { get; set; }
        
        [Required]
        public string DescriptionRu { get; set; }
        
        [Required]
        public string DescriptionEn { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        public string Answer { get; set; }

        public ICollection<UserTaskEntity> Users { get; set; }
        public ICollection<DialogEntity> Dialogs { get; set; }
    }
}
