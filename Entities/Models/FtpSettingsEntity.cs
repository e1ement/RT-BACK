using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class FtpSettingsEntity : AutoincrementEntity
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Address { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
