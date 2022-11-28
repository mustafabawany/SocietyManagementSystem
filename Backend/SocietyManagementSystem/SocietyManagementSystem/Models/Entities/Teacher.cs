using System.ComponentModel.DataAnnotations;

namespace SocietyManagementSystem.Models.Entities
{
    public class Teacher
    {
        [Key]
        public string TeacherId { set; get; }
        public string Name { set; get; }
        public string Employement_Type {set;get;}
    }
}
