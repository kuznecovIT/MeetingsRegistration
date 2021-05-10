using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Registration.Api.Client.Clients;
using Registration.Api.Client.Entities;
using Registration.Api.Client.Enums;

namespace Registration.Api.Client.Clients
{
    public static class ActivityEntityClient
    {
        private const string ActivityEntityUrl = "api/ActivityEntities";
        
        public static async Task<List<Activity>> GetActivities()
        {
            return await BaseClient.GetAll<Activity>(ActivityEntityUrl);
        }
        
        
        public static async Task<Activity> GetActivityById(long activityId)
        {
            return await BaseClient.GetById<Activity>(ActivityEntityUrl, activityId);
        }

        
        public static async Task<HttpResponseMessage> CreateActivity(Activity activity)
        {
            return await BaseClient.Create(ActivityEntityUrl, activity);
        }


        public static async Task<HttpResponseMessage> UpdateActivity(Activity activity)
        {
            return await BaseClient.Update(ActivityEntityUrl, activity);
        }


        public static async Task<HttpResponseMessage> DeleteActivity(Activity activity)
        {
            return await BaseClient.Delete(ActivityEntityUrl, activity);
        }
        
    }
}