using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Registration.Api.Client.Entities;
using Registration.Api.Client.Enums;

namespace Registration.Api.Client.Clients
{
    public static class BaseClient
    {
        /// <summary>
        /// Получение всех записей в таблице БД
        /// </summary>
        /// <param name="apiUrl">Ссылка на api ex: api/entity</param>
        /// <typeparam name="T">Тип экземпляра записи</typeparam>
        /// <returns>Список записей</returns>
        public static async Task<List<T>> GetAll<T>(string apiUrl) where T: IEntity 
        {
            var response = await ApiRequests.SendApiRequest<T>(apiUrl, RequestTypes.Get, new HttpClient());

            var responseStream = await response.Content.ReadAsStreamAsync();
            
            var entities = await JsonSerializer.DeserializeAsync<List<T>>(responseStream);
            
            return entities;
        }
        
        
        /// <summary>
        /// Получение записи по Id из БД 
        /// </summary>
        /// <param name="apiUrl">Ссылка на api ex: api/entity</param>
        /// <param name="entityId">Id записи</param>
        /// <typeparam name="T">Тип экземпляра записи</typeparam>
        /// <returns>Список записей</returns>
        public static async Task<T> GetById<T>(string apiUrl, long entityId) where T: IEntity 
        {
            var response = await ApiRequests.SendApiRequest<T>(apiUrl + @$"\{entityId}", RequestTypes.Get, new HttpClient());

            var responseStream = await response.Content.ReadAsStreamAsync();
            
            var entities = await JsonSerializer.DeserializeAsync<T>(responseStream);
            
            return entities;
        }

        
        /// <summary>
        /// Создание новой записи в таблице БД
        /// </summary>
        /// <param name="apiUrl">Ссылка на api ex: api/entity</param>
        /// <param name="creationEntity">Экземпляр создаваемой записи</param>
        /// <typeparam name="T">Тип экземпляра записи</typeparam>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Create<T>(string apiUrl, T creationEntity) where T: IEntity
        {
            return await ApiRequests.SendApiRequest<T>(apiUrl, RequestTypes.Post, new HttpClient(), creationEntity);
        }
        
        
        /// <summary>
        /// Изменение существующей записи в БД
        /// </summary>
        /// <param name="apiUrl">Ссылка на api ex: api/entity</param>
        /// <param name="updateEntity">Изменяемая сущность</param>
        /// <typeparam name="T">Тип экземпляра записи</typeparam>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Update<T>(string apiUrl, T updateEntity) where T: IEntity
        {
            return await ApiRequests.SendApiRequest<T>(apiUrl + $@"\{updateEntity.GetId()}", RequestTypes.Put,
                new HttpClient(), updateEntity);
        }
        
        
        /// <summary>
        /// Удаление записи из БД
        /// </summary>
        /// <param name="apiUrl">Ссылка на api ex: api/entity</param>
        /// <param name="deleteEntity">Удаляемая сущность</param>
        /// <returns>HttpResponseMessage</returns>
        public static async Task<HttpResponseMessage> Delete<T>(string apiUrl, T deleteEntity) where T: IEntity
        {
            return await ApiRequests.SendApiRequest<MeetingVisitor>(apiUrl + @$"\{deleteEntity.GetId()}", RequestTypes.Delete,
                new HttpClient());
        }
    }
}