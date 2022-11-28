using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyManagementSystem.Models.Entities
{
    public class AddEventsViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Event_Type { get; set; }
        public string Guest_name { get; set; }
        public string Venue { get; set; }
        public DateTime Date_Time { set; get; }
        public string SocietyName { set; get;  }
    }
}
