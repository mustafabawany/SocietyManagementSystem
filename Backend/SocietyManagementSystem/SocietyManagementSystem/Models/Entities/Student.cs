using System.ComponentModel.DataAnnotations;

namespace SocietyManagementSystem.Models.Entities
{
    public class Student
    {
        [Key]
        public string? StudentId { set; get; }
        public string Name { set; get; }
        public string EmailId { set; get; }
        public string Password { set; get; }
    }
}
