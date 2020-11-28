using Entities.Common;
using Entities.Models;

namespace Entities.Dto
{
    public class CategoryDto : AutoincrementObject
    {
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionEn { get; set; }

        public CategoryDto(CategoryEntity entity) : base(entity)
        {
            if (entity == null)
            {
                return;
            }

            TitleRu = entity.TitleRu;
            TitleEn = entity.TitleEn;
            DescriptionRu = entity.DescriptionRu;
            DescriptionEn = entity.DescriptionEn;
        }
    }
}
