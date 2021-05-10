using System;
using System.Collections.Generic;
using System.Linq;
using Registration.Api.Client.Clients;
using Registration.Api.Client.Entities;

namespace Registration.Api.Test
{
    /// <summary>
    /// Тут представлены задачи перечисленные в блоке 'Сервис должен иметь возможность'
    /// В связи с отсутствием опыта frontend не успел это всё вывести в интернет с интерактивностью и кнопочками,
    /// поэтому функциональность представлена вот так...
    ///
    /// Как бы сделал если бы был опыт: создал бы React-redux-app, настроил бы в web api 'cors',
    /// и далее как-нибудь там уже обращался к апи через 'axios' и динамически выводил результат
    /// </summary>
    public static class ServiceTasks
    {
        /// <summary>
        /// Регистрация нового события
        /// </summary>
        /// <param name="meeting">Экземпляр события для регистрации</param>
        public static void RegisterNewMeeting(Meeting meeting)
        {
            Console.WriteLine(MeetingEntityClient.CreateMeeting(meeting).Result);
        }


        /// <summary>
        /// Изменение выбранного события
        /// </summary>
        /// <param name="meeting">Событие с внесенными изменениями</param>
        public static void UpdateMeeting(Meeting meeting)
        {
            Console.WriteLine(MeetingEntityClient.UpdateMeeting(meeting).Result);
        }
        
        
        /// <summary>
        /// Закрыть событие
        /// </summary>
        /// <param name="meeting">Экземпляр события для закрытия</param>
        public static void CloseMeeting(Meeting meeting)
        {
            try
            {
                var closedActivityId = ActivityEntityClient.GetActivities().Result
                    .FirstOrDefault(activity => activity.Name == "Closed")
                    .ActivityId;
                
                meeting.ActivityId = closedActivityId;
            
                UpdateMeeting(meeting);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Activity с названием Closed не существует в таблице Activities");
            }
        }
        
        
        /// <summary>
        /// Удалить события без назначенных посетителей
        /// </summary>
        public static void DeleteMeetingsWithNoVisitors()
        {
            var meetings = MeetingEntityClient.GetMeetings().Result;
            var meetingVisitors = MeetingVisitorEntityClient.GetMeetingsVisitors().Result;

            meetings.Where(meeting => meetingVisitors
                    .Select(m => m.MeetingId).All(id => id != meeting.MeetingId))
                .ToList()
                .ForEach(meeting => Console.WriteLine(MeetingEntityClient.DeleteMeeting(meeting).Result));
        }
        
        
        /// <summary>
        /// Зарегистрировать посетителя
        /// </summary>
        /// <param name="visitor">Экземпляр посетителя для регистрации</param>
        public static void RegisterNewVisitor(Visitor visitor)
        {
            Console.WriteLine(VisitorEntityClient.CreateVisitor(visitor).Result);
        }


        /// <summary>
        /// Изменить данные посетителя
        /// </summary>
        /// <param name="visitor">Экземпляр посетителя</param>
        public static void UpdateVisitor(Visitor visitor)
        {
            Console.WriteLine(VisitorEntityClient.UpdateVisitor(visitor).Result);
        }
        
        
        /// <summary>
        /// Удалить посетителя из события
        /// </summary>
        /// <param name="meetingVisitor">Экзепляр регистрации посетителя на событие</param>
        public static void DeleteVisitorFromMeeting(MeetingVisitor meetingVisitor)
        {
            Console.WriteLine(MeetingVisitorEntityClient.DeleteMeetingVisitor(meetingVisitor).Result);
        }        
        
        
        /// <summary>
        /// Зарегистрировать посетителя в событии
        /// </summary>
        /// <param name="visitor">Экземпляр посетителя</param>
        /// <param name="meeting">Экземпляр события</param>
        public static void AttachVisitorToMeeting(Visitor visitor, Meeting meeting)
        {
            var meetingVisitors = MeetingVisitorEntityClient.GetMeetingsVisitors().Result;
            
            if (!meetingVisitors.Any(meetingVisitor =>
                meetingVisitor.MeetingId == meeting.MeetingId && meetingVisitor.VisitorId == visitor.VisitorId))
            {
                Console.WriteLine(MeetingVisitorEntityClient.CreateMeetingVisitor(new MeetingVisitor
                    {MeetingId = meeting.GetId(), VisitorId = visitor.GetId()}).Result);
            }
            else
            {
                Console.WriteLine($"Посетитель {visitor.FullName} уже зарегистрирован на событие {meeting.Name}");
            }
        }


        /// <summary>
        /// Вывести отчет в виде количества зарегистрированных посетителей для события
        /// </summary>
        /// <param name="meeting">Экземпляр события</param>
        public static void GetVisitorsCountForMeeting(Meeting meeting)
        {
            Console.WriteLine(string.Format("На событие с названием {0} зарегистрировано {1} посетителей.",
                meeting.Name, GetVisitorsForMeetingRecord(meeting).Count));
        }
        
        
        /// <summary>
        /// Получить список пользователей зарегистрированых на событие
        /// </summary>
        /// <param name="meeting">Экземпляр события</param>
        /// <returns>Список пользователей зарегистрированных на событие</returns>
        public static List<Visitor> GetVisitorsForMeetingRecord(Meeting meeting)
        {
            var visitors = new List<Visitor>();
            
            MeetingVisitorEntityClient.GetMeetingsVisitors().Result
                .Where(visitor => visitor.MeetingId == meeting.MeetingId)
                .ToList()
                .ForEach(visitor => visitors.Add(VisitorEntityClient.GetVisitorById(visitor.VisitorId).Result));

            return visitors;
        }
        
        
        /// p.s. Мне казалось такое тоже надо было сделать, но оказывается этого не было в списке к реализации...
        /// <summary>
        /// Закрыть истекшие события
        /// </summary>
        public static void CloseMeetingsIfExpired()
        {
            try
            {
                var closedActivityId = ActivityEntityClient.GetActivities().Result
                    .FirstOrDefault(activity => activity.Name == "Closed")
                    .ActivityId;
            
                var expiredMeetings = MeetingEntityClient.GetMeetings().Result
                    .Where(meeting => meeting.Date < DateTime.Now)
                    .ToList();

                foreach (var meeting in expiredMeetings)
                {
                    meeting.ActivityId = closedActivityId;
                    Console.WriteLine(MeetingEntityClient.UpdateMeeting(meeting));
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Activity с названием Closed не существует в таблице Activities");
            }
        }
    }
}