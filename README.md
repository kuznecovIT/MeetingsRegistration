# MeetingsRegistration

Надеюсь я успею сюда написать инструкцию как этим всем пользоваться...
( ͡° ͜ʖ ͡°)


1. Задать реквизиты PostgreSQL в ConnectionStrings файла appsettings.json проекта Registration.Api 'DefaultConnection' 
2. Изменить уровень доступности свойств в Registration.DAL на public, 
    иначе зависимости между таблицами в базе данных не установятся при запуске initial миграции
3. Выполнить в менеджере пакетов nuget Enable-migrations, а затем Add-Migration initial
4. Установить уровень свойств на private для работы API в папке Entities проекта Registration.DAL
     MeetingEntity: свойство Activity -> private
     MeetingVisitorEntity: свойства Meeting, Visitor -> private
5. Все требуемые в задании возможности вызываются в файле Program.cs проекта Registration.Api.Test, 
    сама реализация находится в файле ServiceTask.cs, так же там описано почему это все не выведено в нормальный веб-сервис
6. Запустить Registration.Api
7. Запустить Registration.Api.Test с предварительно разкоменнтированными тасками 


Прошу прощения за сумбур, я банально не успел всё отточить до идеала.

**Немного информации по проектам**

Registration.DAL - проект для работы с базой данных PostgreSQL средствами EF Core
описаны Entity - по сути таблицы базы данных представляющие сущности проекта
через него проводятся миграции и создание базы методом CodeFirst 

Registration.Api - проект WebApi, через него взаимодействуем с базой данных
Там настроен Swagger для удобной отдалки Api, созданы базовые контроллеры для обращения к Entity проекта DAL.

Registration.Api.Client - проект REST-клиент для обращения к WebApi, описаны Api запросы и JSON сериализация

Registration.Api.Test - проект для проверки всего выше описанного, там в том числе в файле ServiceTasks.cs реализованы изначальные
требования к проекту, а в Program.cs представлены примеры использования этих реализаций.
