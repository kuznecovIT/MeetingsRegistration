using System.Text.Json.Serialization;

namespace Registration.Api.Client.Entities
{
    public class Activity : IEntity
    {
        [JsonPropertyName("activityId")]
        public long ActivityId { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }


        public long GetId() => ActivityId;

        
        public override string ToString()
        {
            return $"Activity ID: {ActivityId} \n" +
                   $"\tActivity Name: {Name}";
        }
    }
}