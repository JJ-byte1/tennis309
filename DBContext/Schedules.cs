using System.ComponentModel.DataAnnotations;

namespace Groupweb.DBContext
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        [Required]
        [StringLength(255)]
        public string EventName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        public int? CoachID { get; set; } // Nullable foreign key

        // Navigation properties
        public virtual Coach Coach { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
