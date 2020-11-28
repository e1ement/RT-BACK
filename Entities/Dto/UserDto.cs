using Entities.Common;
using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities.Dto
{
    public class UserDto : AutoincrementObject
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public int Progress { get; set; }
        public LanguageLevelEnum Level { get; set; }
        public DateTime LastActivityTime { get; set; }
        public NotificationEnum Notification { get; set; }
        public PaymentLevelEnum PaymentLevel { get; set; }

        public List<UserTaskDto> Tasks { get; set; }

        public UserDto(UserEntity entity) : base(entity)
        {
            if (entity == null)
            {
                return;
            }

            Name = entity.Name;
            Picture = entity.Picture;
            // предполагается вычисление = общее кол-во заданий юзера / выполненные + зависимость от рейтинга
            Progress = entity.Progress;
            Level = entity.Level;
            LastActivityTime = entity.LastActivityTime;
            Notification = entity.Notification;
            PaymentLevel = entity.PaymentLevel;
            Tasks = new List<UserTaskDto>();

            if (entity.Tasks != null)
            {
                Tasks.AddRange(entity.Tasks.Select(s => new UserTaskDto(s)));
            }
        }
    }
}
