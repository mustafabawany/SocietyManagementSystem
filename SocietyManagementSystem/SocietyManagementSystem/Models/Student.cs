using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyManagementSystem.Models
{
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email_id { get; set; }

        public Student(string id, string name, string email_id)
        {
            this.id = id;
            this.name = name;
            this.email_id = email_id;
        }
    }
}