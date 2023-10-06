using System.ComponentModel.DataAnnotations;

namespace Groupweb.DBContext
{
    public class Member
    {
        public int MemberID { get; set; }

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

        // Navigation property for enrollments
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
