using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyManagementSystem.Models.Entities
{
    public class Registration
    {
        [Key]
        public Guid RegistrationId { get; set; }

        [ForeignKey("Student")]
        public string? StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Event")]
        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}
