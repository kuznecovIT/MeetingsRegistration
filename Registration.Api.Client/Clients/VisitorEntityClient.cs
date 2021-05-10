using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Registration.Api.Client.Entities;

namespace Registration.Api.Client.Clients
{
    public static class VisitorEntityClient
    {
        private const string VisitorUrl = "api/VisitorEntities";
        
        public static async Task<List<Visitor>> GetVisitors()
        {
            return await BaseClient.GetAll<Visitor>(VisitorUrl);
        }
        
        
        public static async Task<Visitor> GetVisitorById(long visitorId)
        {
            return await BaseClient.GetById<Visitor>(VisitorUrl, visitorId);
        }

        
        public static async Task<HttpResponseMessage> CreateVisitor(Visitor visitor)
        {
            return await BaseClient.Create(VisitorUrl, visitor);
        }


        public static async Task<HttpResponseMessage> UpdateVisitor(Visitor visitor)
        {
            return await BaseClient.Update(VisitorUrl, visitor);
        }


        public static async Task<HttpResponseMessage> DeleteVisitor(Visitor visitor)
        {
            return await BaseClient.Delete(VisitorUrl, visitor);
        }
    }
}