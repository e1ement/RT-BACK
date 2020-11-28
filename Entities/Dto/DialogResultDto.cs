using Entities.Models;

namespace Entities.Dto
{
    public class DialogResultDto
    {
        public int TaskId { get; set; }
        public string TaskTitleRu { get; set; }
        public string TaskTitleEn { get; set; }

        // Соответствие теме задания
        public int TaskRelevance { get; set; }

        // Чистота произношения слов
        public int WordsPurity { get; set; }

        // Словарный запас
        public int Vocabulary { get; set; }

        public DialogResultDto(DialogEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            TaskId = entity.TaskId;
            TaskTitleRu = entity.Task.TitleRu;
            TaskTitleEn = entity.Task.TitleEn;

            // Позднее здесь будет использоваться результат анализа текстового диалога для итоговой оценки выполнения задания
            // начисления баллов и корректировки дальнейшей программы обучения
            TaskRelevance = 78;
            WordsPurity = 34;
            Vocabulary = 97;
        }
    }
}
