using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Lib.GoogleClendar
{
    /// <summary>
    /// הקוד מבוסס על קוד מהלינק:
    /// https://stackoverflow.com/q/55103032
    /// </summary>
    public static class Clendar
    {
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        static string[] Scopes = { CalendarService.Scope.Calendar };
        static CalendarService service;
        static EventsResource.ListRequest request;

        static Clendar()
        {
            //משתנה ששומר את פרטי הזדהות המשתמש
            UserCredential credential = null;

            //מחרוזת שמכילה את פרטי האפליקציה, מחרוזת זו התקבלה בזמן רישום האפליקציה מול גוגל
            string json = @"
{""installed"":{""client_id"":""696972335529-cj7ga248q361atfie6uatvarnc6ectml.apps.googleusercontent.com"",""project_id"":""central-spot-391217"",""auth_uri"":""https://accounts.google.com/o/oauth2/auth"",""token_uri"":""https://oauth2.googleapis.com/token"",""auth_provider_x509_cert_url"":""https://www.googleapis.com/oauth2/v1/certs"",""client_secret"":""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"",""redirect_uris"":[""http://localhost""]}}
"; ;

            //נתיב תיקייה בו יישמר הטוקן, שזהו הזיהוי שלנו מול גוגל
            //string path = @"D:\התקייה לקבצי הלימודים של נטע\forwebsite";
            //string dir = Path.Combine(Directory.GetCurrentDirectory(), "auth");
            string dir = Path.Combine("C:\\", "auth");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }



            //שם קובץ שישמור את הטוקן
            //string credPath = "token";
            //הנתיב המלא בו יישמר קובץ שיכיל את הטוקן
            //string tokenPath = Path.Combine(dir, credPath);
            //הפיכת הסטרינג לסטרים
            using (var stream = GenerateStreamFromString(json))
            {
                //יצירת משתנה עבור זיהוי מול גוגל
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(dir, true)).Result;

            }
            //יצירת משתנה מסוג יומן, עם ההזדהות ושם האפליקציה שיצרנו
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            request = service.Events.List("primary");
        }

        //פעולה המקבלת מחרוזת, ומחזירה משתנה מסוג סטרים.
        //זו פעולה שממירה סטרינג לסטרים
        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// פעולה שמטרתה להוסיף אירוע ליומן של גוגל
        /// </summary>
        /// <param name="clendarEvent">
        /// משתנה שמכיל את כל פרטי האירוע, כמו ממתי עד מתי מתי, למי לשלוח וכו
        /// </param>
        public static void AddEvent(ClendarEvent clendarEvent)
        {
            // Define parameters of request.
            //יצירת משתנה בקשה, שיכיל את נתוני הבקשה אל מול גוגל

            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // משיכת האירועים הקיימים.
            //ביצוע הבקשה בפועל
            Events events = request.Execute();
            //בדיקה אם קיימים אירועים
            if (events.Items != null && events.Items.Count > 0)
            {
                //מעבר בלולאה על כל האירועים
                foreach (var eventItem in events.Items)
                {
                    //זמן תחילת האירוע
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            //יצירת אירוע חדש
            var ev = new Event();
            //הגדרת זמן תחילת האירוע
            EventDateTime start = new EventDateTime();
            start.DateTime = clendarEvent.Start;//new DateTime(2022, 1, 29, 10, 0, 0);
            //הגדרת זמן סיום האירוע
            EventDateTime end = new EventDateTime();
            end.DateTime = clendarEvent.End;

            ev.Start = start;
            ev.End = end;
            ev.Summary = clendarEvent.Summary;
            ev.Description = clendarEvent.Description;
            var calendarId = "primary";

            //למי לשלוח את האירוע
            ev.Attendees = new List<EventAttendee>()
      {
        new EventAttendee() { Email = clendarEvent.EmailTo},
         
         // new EventAttendee() { Email = "testforapp231@gmail.com"}
      };
            //string EmailToParent,string EmailToBabySitter
            //הכנסת האירוע ליומן
            EventsResource.InsertRequest req = service.Events.Insert(ev, calendarId);
            //שיציג התראה למקבלי הזימון
            req.SendNotifications = true;
            //הוצאה לפועל של הכנסת האירוע ליומן
            Event createdEvent = req.Execute();
            //Console.WriteLine("Event created: %s\n", ev.HtmlLink);

        }


        public static void DeleteEvent(DateTime date)//26/11/2022 15:00:00
        {


            Events events = request.Execute();
            //בדיקה אם קיימים אירועים
            if (events.Items != null && events.Items.Count > 0)
            {
                //מעבר בלולאה על כל האירועים
                foreach (var eventItem in events.Items)
                {
                    Debug.WriteLine("init test");
                    //זמן תחילת האירוע
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                    if (date.Year == eventItem.Start.DateTime.Value.Year &&
                        date.Month == eventItem.Start.DateTime.Value.Month &&
                        date.Day == eventItem.Start.DateTime.Value.Day &&
                         date.Hour == eventItem.Start.DateTime.Value.Hour)
                    {
                        service.Events.Delete("primary", eventItem.Id).Execute();
                        Console.WriteLine("event was canceled");
                        Debug.WriteLine("event caneled");
                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
        }


    }
}
