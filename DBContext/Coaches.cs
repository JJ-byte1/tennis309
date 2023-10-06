using System.ComponentModel.DataAnnotations;

namespace Groupweb.DBContext
{
    public class Coach
    {
        public int CoachID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public string Biography { get; set; }

        // Navigation property for schedules
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
