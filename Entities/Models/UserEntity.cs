using Entities.Enums;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class UserEntity : AutoincrementEntity
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public int Progress { get; set; }
        public LanguageLevelEnum Level { get; set; }
        public DateTime LastActivityTime { get; set; }
        public NotificationEnum Notification { get; set; }
        public PaymentLevelEnum PaymentLevel { get; set; }

        public ICollection<UserTaskEntity> Tasks { get; set; }
        public ICollection<DialogEntity> Dialogs { get; set; }
    }
}
