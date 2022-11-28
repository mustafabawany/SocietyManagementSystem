using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyManagementSystem.Models.Entities
{
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Event_Type { get; set; }
        public string? Guest_name { get; set; }
        public string Venue { get; set; }
        public DateTime Date_Time { set; get; }

        //Navigation
        [ForeignKey("Society")]
        public string SocietyName { get; set; }
        public Society Society { get; set; }
    }
}
