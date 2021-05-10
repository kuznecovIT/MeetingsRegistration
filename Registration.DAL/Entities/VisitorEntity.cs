using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meetings.DAL.Entities
{
    public class VisitorEntity
    {
        [Key]
        public long VisitorId { get; set; }
        
        public string FullName { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public char Sex { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
    }
}