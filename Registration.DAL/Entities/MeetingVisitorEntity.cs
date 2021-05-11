using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetings.DAL.Entities
{
    public class MeetingVisitorEntity
    {
        [Key]
        public long MeetingVisitorId { get; set; }
        
        [ForeignKey("Meeting")]
        public long MeetingId { get; set; }
        
        [ForeignKey("Visitor")]
        public long VisitorId { get; set; }

        public MeetingEntity Meeting { get; set; }

        public VisitorEntity Visitor { get; set; }
    }
}
