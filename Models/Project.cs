using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeBillingSystemProject.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string ProjectName { get; set; } // Name of the project

        [MaxLength(500)]
        public string Description { get; set; } // Optional project description

        [Required]
        public int ClientId { get; set; } // Foreign key to Client

        [ForeignKey("ClientId")]
        public Client Client { get; set; } // Navigation property for Client

        [Required]
        public int UserId { get; set; } // Foreign key to User managing this project

        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property for User managing this project

        public ICollection<TimeEntry> TimeEntries { get; set; } // List of time entries for this project
    }
}
