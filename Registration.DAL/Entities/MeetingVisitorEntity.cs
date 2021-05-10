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

        private MeetingEntity Meeting { get; set; }

        private VisitorEntity Visitor { get; set; }
    }
}