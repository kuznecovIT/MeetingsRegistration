using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Registration.Api.Client.Entities;

namespace Registration.Api.Client.Clients
{
    public static class MeetingVisitorEntityClient
    {
        private const string MeetingVisitorUrl = "api/MeetingVisitorEntities";

        public static async Task<List<MeetingVisitor>> GetMeetingsVisitors()
        {
            return await BaseClient.GetAll<MeetingVisitor>(MeetingVisitorUrl);
        }


        public static async Task<MeetingVisitor> GetMeetingVisitorById(long meetingVisitorId)
        {
            return await BaseClient.GetById<MeetingVisitor>(MeetingVisitorUrl, meetingVisitorId);
        }


        public static async Task<HttpResponseMessage> CreateMeetingVisitor(MeetingVisitor meetingVisitor)
        {
            return await BaseClient.Create(MeetingVisitorUrl, meetingVisitor);
        }


        public static async Task<HttpResponseMessage> UpdateMeetingVisitor(MeetingVisitor meetingVisitor)
        {
            return await BaseClient.Update(MeetingVisitorUrl, meetingVisitor);
        }


        public static async Task<HttpResponseMessage> DeleteMeetingVisitor(MeetingVisitor meetingVisitor)
        {
            return await BaseClient.Delete(MeetingVisitorUrl, meetingVisitor);
        }
        
        
        /*public static async Task<List<MeetingVisitor>> GetMeetingsVisitors()
        {
            //await BaseClient.GetAll<MeetingVisitor>(MeetingVisitorUrl);
            var response = await ApiRequests.SendApiRequest<MeetingVisitor>(MeetingVisitorUrl, RequestTypes.Get, new HttpClient());

            var z = await response.Content.ReadAsStreamAsync();
            
            var meetings = await JsonSerializer.DeserializeAsync<List<MeetingVisitor>>(z);
            
            return meetings;
        }
        
        
        public static HttpResponseMessage CreateMeetingVisitor(MeetingVisitor meetingVisitor)
        {
            return ApiRequests.SendApiRequest<MeetingVisitor>(MeetingVisitorUrl, RequestTypes.Post, new HttpClient(), meetingVisitor).Result;
        }
        
        
        public static async void DeleteMeetingVisitor(long meetingId)
        {
            await ApiRequests.SendApiRequest<MeetingVisitor>(MeetingVisitorUrl + @$"\{meetingId}", RequestTypes.Delete, new HttpClient());
        }

        
        public static HttpResponseMessage UpdateMeetingVisitor(MeetingVisitor meetingVisitor)
        {
            return ApiRequests.SendApiRequest<MeetingVisitor>(MeetingVisitorUrl + $@"\{meetingVisitor.MeetingVisitorId}", RequestTypes.Put, new HttpClient(), meetingVisitor).Result;
        }*/
    }
}