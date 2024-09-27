using System.ComponentModel.DataAnnotations;

namespace TimeBillingSystemProject.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; } // Primary key

        [Required]
        [MaxLength(100)]
        public string ClientName { get; set; } // Client's name

        [MaxLength(200)]
        public string ContactInfo { get; set; } // Optional contact info for the client

        public ICollection<Project> Projects { get; set; } // List of projects for this client
    }
}
