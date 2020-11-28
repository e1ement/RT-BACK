using Entities.Common;
using Entities.Models;

namespace Entities.Dto
{
    public class TaskDto : AutoincrementObject
    {
        public CategoryDto Category { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionEn { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }

        public TaskDto(TaskEntity entity) : base(entity)
        {
            if (entity == null)
            {
                return;
            }

            if (entity.Category != null)
                Category = new CategoryDto(entity.Category);
            TitleRu = entity.TitleRu;
            TitleEn = entity.TitleEn;
            DescriptionRu = entity.DescriptionRu;
            DescriptionEn = entity.DescriptionEn;
            Text = entity.Text;
            Answer = entity.Answer;
        }
    }
}
