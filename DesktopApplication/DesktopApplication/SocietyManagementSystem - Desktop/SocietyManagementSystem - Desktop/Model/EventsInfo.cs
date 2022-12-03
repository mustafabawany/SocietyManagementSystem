using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietyManagementSystem___Desktop.Model
{
    public class EventsInfo
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Event_Type { get; set; }
        public string Guest_name { get; set; }
        public string Venue { get; set; }
        public DateTime Date_Time { set; get; }
        public string SocietyName { get; set; }
    }
}
