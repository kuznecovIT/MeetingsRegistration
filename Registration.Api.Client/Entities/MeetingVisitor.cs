using System.Text.Json.Serialization;
using Meetings.DAL.Entities;

namespace Registration.Api.Client.Entities
{
    public class MeetingVisitor : IEntity
    {
        [JsonPropertyName("meetingVisitorId")]
        public long MeetingVisitorId { get; set; }
        
        [JsonPropertyName("meetingId")]
        public long MeetingId { get; set; }
        
        [JsonPropertyName("visitorId")]
        public long VisitorId { get; set; }

        [JsonPropertyName("meeting")]
        private MeetingEntity Meeting { get; set; }

        [JsonPropertyName("visitor")]
        private VisitorEntity Visitor { get; set; }


        public long GetId() => MeetingVisitorId;

        public override string ToString()
        {
            return $"MeetingVisitor ID: {MeetingVisitorId} \n" +
                   $"\tMeeting ID: {MeetingId} \n" +
                   $"\tVisitor ID: {VisitorId}";
        }
    }
}