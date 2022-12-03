using System;


namespace SocietyManagementSystem.Models
{
    public class EventInfo
    {
    //masla ho tou isko wapis GUID kardena 
        public string EventId { get; set; }
        public string Name { get; set; }
        public string Event_Type { get; set; }
        public string Guest_name { get; set; }
        public string Venue { get; set; }
        public DateTime Date_Time { set; get; }

        public string SocietyName { get; set; }
    }
}