using System;
using System.Text.Json.Serialization;

namespace Registration.Api.Client.Entities
{
    public class Visitor : IEntity
    {
        [JsonPropertyName("visitorId")]
        public long VisitorId { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }
        
        [JsonPropertyName("sex")]
        public char Sex { get; set; }
        
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }


        public long GetId() => VisitorId;


        public override string ToString()
        {
            return $"Visitor ID: {VisitorId} \n" +
                   $"\tVisitor FullName: {FullName} \n" +
                   $"\tVisitor BDay: {Birthday} \n" +
                   $"\tVisitor SEX: {Sex} \n" +
                   $"\tVisitor Phone Number: {PhoneNumber} \n" +
                   $"\tVisitor Email: {Email}";
        }
    }
}