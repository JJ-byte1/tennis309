using System.Diagnostics.Metrics;

namespace Groupweb.DBContext
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        public int MemberID { get; set; }
        public int ScheduleID { get; set; }

        // Navigation properties
        public virtual Member Member { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
