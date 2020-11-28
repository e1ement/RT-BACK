using Entities.Enums;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Dto
{
    public class UserTaskDto
    {
        public int TaskId { get; set; }
        public CategoryDto Category { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionEn { get; set; }
        public string Text { get; set; }
        public List<DialogDto> Dialog { get; set; }
        public string FileName { get; set; }
        public RatingEnum Rating { get; set; }
        public string AiRecommendation { get; set; }
        public string TutorRecommendation { get; set; }
        public bool IsCompleted { get; set; }

        public UserTaskDto(UserTaskEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            TaskId = entity.TaskId;
            if (entity.Task.Category !=null)
                Category = new CategoryDto(entity.Task.Category);
            TitleRu = entity.Task.TitleRu;
            TitleEn = entity.Task.TitleEn;
            DescriptionRu = entity.Task.DescriptionRu;
            DescriptionEn = entity.Task.DescriptionEn;
            Text = entity.Task.Text;
            FileName = entity.FileName;
            Rating = entity.Rating;
            AiRecommendation = entity.AiRecommendation;
            TutorRecommendation = entity.TutorRecommendation;
            IsCompleted = entity.IsCompleted;

            if (entity.Task.Dialogs != null)
            {
                Dialog = new List<DialogDto>();
                Dialog.AddRange(entity.Task.Dialogs.Where(x => x.UserId == entity.UserId).Select(s => new DialogDto(s)));
            }
        }
    }
}
