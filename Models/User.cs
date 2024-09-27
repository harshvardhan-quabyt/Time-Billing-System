using System.ComponentModel.DataAnnotations;

namespace TimeBillingSystemProject.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // Primary key

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } // Unique username for login

        [Required]
        public string PasswordHash { get; set; } // Hashed password

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } // User role (e.g., Admin, User)

        public ICollection<TimeEntry> TimeEntries { get; set; } // List of time entries for the user
        public ICollection<Project> Projects { get; set; } // List of projects assigned to the user
    }
}
