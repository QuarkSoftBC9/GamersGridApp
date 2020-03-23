using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamersGridApp.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        public User User { get; set; }
        public Notification Notification { get; set; }
        public bool IsRead { get; set; }

        public UserNotification()
        {

        }
    }
}