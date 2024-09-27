using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimeBillingSystemProject.Models;

namespace TimeBillingSystemProject.Models
{
    public class TimeEntry
    {
        [Key]
        public int TimeEntryId { get; set; } // Primary key

        [Required]
        public DateTime Date { get; set; } // Date of the time entry

        [Required]
        public decimal HoursWorked { get; set; } // Number of hours worked (e.g., 1.5 for 1 hour and 30 minutes)

        [MaxLength(500)]
        public string Description { get; set; } // Optional description of the work done

        [Required]
        public int ProjectId { get; set; } // Foreign key to Project

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } // Navigation property for Project

        // You can also create a User field if you want to associate a TimeEntry directly with a User
        public int UserId { get; set; }
        public User User { get; set; }  // Navigation Property for User

    }
}
