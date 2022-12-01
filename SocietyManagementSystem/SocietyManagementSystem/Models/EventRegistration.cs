using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyManagementSystem.Models
{
    public class EventRegistration
    {
        public string studentId { get; set; }
        public Guid eventId { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}