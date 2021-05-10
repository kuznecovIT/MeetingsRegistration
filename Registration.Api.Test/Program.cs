using System;
using System.Linq;
using System.Threading.Tasks;
using Registration.Api.Client.Clients;
using Registration.Api.Client.Entities;

namespace Registration.Api.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // СОЗДАНИЕ 'Closed' Activity ДЛЯ ВОЗМОЖНОСТИ 'ЗАКАНЧИВАТЬ' СОБЫТИЯ
            //ActivityEntityClient.CreateActivity(new Activity {Name = "Closed"});

            
            // 1. ПРИМЕР РЕГИСТРАЦИИ НОВОГО СОБЫТИЯ
            // var meeting = new Meeting {Name = "NEWMEETING", Date = DateTime.Now, Description = "NEW", ActivityId = 19};
            //ServiceTasks.RegisterNewMeeting(meeting);
            

            // 2. ПРИМЕР ОБНОВЛЕНИЯ СОБЫТИЯ
            //var updatedMeeting = MeetingEntityClient.GetMeetings().Result.FirstOrDefault();
            //updatedMeeting.Name = "UPDATED";
            //ServiceTasks.UpdateMeeting(updatedMeeting);
            
            
            // 3. ПРИМЕР ЗАКРЫТИЯ СОБЫТИЯ
            //var meetingToClose = MeetingEntityClient.GetMeetings().Result.FirstOrDefault();
            //ServiceTasks.CloseMeeting(meetingToClose);
            
            
            // 4. ПРИМЕР УДАЛЕНИЯ СОБЫТИЙ БЕЗ ПОСЕТИТЕЛЕЙ
            //ServiceTasks.DeleteMeetingsWithNoVisitors();
            
            
            // 5. ПРИМЕР РЕГИСТРАЦИИ ПОСЕТИТЕЛЕЙ
            //var visitor = new Visitor {FullName = "NEWVISITOR", Birthday = DateTime.Now, Email = "new@new.new", Sex = 'n', PhoneNumber = "1000-7"};
            //ServiceTasks.RegisterNewVisitor(visitor);
            
            
            // 5.1. ПРИМЕР ЗАКРЕПЛЕНИЯ ПОСЕТИТЕЛЯ ЗА СОБЫТИЕМ
            //var visitor = VisitorEntityClient.GetVisitors().Result.FirstOrDefault();
            //var meeting = MeetingEntityClient.GetMeetings().Result.FirstOrDefault();
            //ServiceTasks.AttachVisitorToMeeting(visitor, meeting);
            
            
            // 6. ПРИМЕР УДАЛЕНИЯ ПОСЕТИТЕЛЯ ИЗ СОБЫТИЯ
            //var meetingVisitor = MeetingVisitorEntityClient.GetMeetingsVisitors().Result.FirstOrDefault();
            //ServiceTasks.DeleteVisitorFromMeeting(meetingVisitor);
            
            
            // 7. ПРИМЕР ИЗМЕНЕНИЯ ДАННЫХ ПОСЕТИТЕЛЯ
            //var visitor = VisitorEntityClient.GetVisitors().Result.FirstOrDefault();
            //visitor.FullName = "UPDATED";
            //ServiceTasks.UpdateVisitor(visitor);

            
            // 8. ПРИМЕР ОТЧЕТА ПО КОЛИЧЕСТВУ ЗАРЕГИСТРИРОВАННЫХ ПОЛЬЗОВАТЕЛЕЙ НА СОБЫТИЕ
            //var meeting = MeetingEntityClient.GetMeetings().Result.FirstOrDefault();
            //ServiceTasks.GetVisitorsCountForMeeting(meeting);
        }
    }
}