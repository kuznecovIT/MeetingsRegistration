using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetings.DAL.Entities
{
    public class MeetingEntity
    {
        [Key]
        public long MeetingId { get; set; }
        
        public string Name { get; set; }
        
        public DateTime Date { get; set; }

        [ForeignKey("Activity")]
        public long ActivityId { get; set; }
        
        public string Description { get; set; }

        public ActivityEntity Activity { get; set; }
    }
}
