using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CategoryEntity : AutoincrementEntity
    {
        [Required]
        public string TitleRu { get; set; }

        [Required]
        public string TitleEn { get; set; }

        [Required]
        public string DescriptionRu { get; set; }

        [Required]
        public string DescriptionEn { get; set; }

        public ICollection<TaskEntity> Tasks { get; set; }
    }
}
