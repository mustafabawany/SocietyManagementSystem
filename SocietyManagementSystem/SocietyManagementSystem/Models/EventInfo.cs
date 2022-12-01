using System;


namespace SocietyManagementSystem.Models
{
    public class EventInfo
    {
   
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Event_Type { get; set; }
        public string Guest_name { get; set; }
        public string Venue { get; set; }
        public DateTime Date_Time { set; get; }

        public Guid SocietyId { get; set; }
    }
}