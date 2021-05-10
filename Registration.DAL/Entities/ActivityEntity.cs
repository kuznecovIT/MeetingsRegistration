using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetings.DAL.Entities
{
    public class ActivityEntity
    {
        [Key]
        public long ActivityId { get; set; } 
        
        public string Name { get; set; }
    }
}