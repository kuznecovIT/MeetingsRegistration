using System;
using System.Text.Json.Serialization;

namespace Registration.Api.Client.Entities
{
    public class Meeting : IEntity
    {
        [JsonPropertyName("meetingId")]
        public long MeetingId { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        
        [JsonPropertyName("activityId")]
        public long ActivityId { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }

        public long GetId() => MeetingId;

        public override string ToString()
        {
            return $"Meeting ID: {MeetingId} \n" +
                   $"\tMeeting Name: {Name} \n" +
                   $"\tMeeting Date: {Date} \n" +
                   $"\tActivity ID: {ActivityId} \n" +
                   $"\tMeeting Description: {Description}";
        }
    }
}