using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Registration.Api.Client.Entities;

namespace Registration.Api.Client.Clients
{
    public static class MeetingEntityClient
    {
        private const string MeetingEntityUrl = "api/MeetingEntities";
        
        
        public static async Task<List<Meeting>> GetMeetings()
        {
            return await BaseClient.GetAll<Meeting>(MeetingEntityUrl);
        }
        
        
        public static async Task<Meeting> GetMeetingById(long meetingId)
        {
            return await BaseClient.GetById<Meeting>(MeetingEntityUrl, meetingId);
        }

        
        public static async Task<HttpResponseMessage> CreateMeeting(Meeting meeting)
        {
            return await BaseClient.Create(MeetingEntityUrl, meeting);
        }


        public static async Task<HttpResponseMessage> UpdateMeeting(Meeting meeting)
        {
            return await BaseClient.Update(MeetingEntityUrl, meeting);
        }


        public static async Task<HttpResponseMessage> DeleteMeeting(Meeting meeting)
        {
            return await BaseClient.Delete(MeetingEntityUrl, meeting);
        }
    }
}