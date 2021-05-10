using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Registration.Api.Client.Entities;
using Registration.Api.Client.Enums;

namespace Registration.Api.Client
{
    public static class ApiRequests
    {
        public static async Task<HttpResponseMessage> SendApiRequest<T>(string apiUrl, RequestTypes requestType,
            HttpClient client, T entity = default, int deleteId = default) where T : IEntity
        {
            var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("http://localhost:5000/"); // Хотелось подкреплять это значение из launchSettings.json, но не успел разобраться 

            return requestType switch
            {
                RequestTypes.Get => await client.GetAsync(apiUrl),
                RequestTypes.Post => await client.PostAsync(apiUrl, content),
                RequestTypes.Put => await client.PutAsync(apiUrl, content),
                RequestTypes.Delete => await client.DeleteAsync(apiUrl),
                _ => new HttpResponseMessage(statusCode: HttpStatusCode.BadRequest)
            };
        }
    }
}