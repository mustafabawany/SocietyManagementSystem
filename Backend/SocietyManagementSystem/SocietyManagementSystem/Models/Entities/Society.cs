using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyManagementSystem.Models.Entities
{
    public class Society
    {
        [Key]
        public Guid SocietyId { set; get; }
        public string Name { set; get; }
        public string Announcement { set; get; }
        public int Budget { set; get; }

        [ForeignKey("Student")]
        public string? President_id { set; get; }
        public string? Vice_president_id { set; get; }
        public string? Treasurer_id { set; get; }
        public string? Gs_id { set; get; }
        public Student Student { set; get; }

        [ForeignKey("Teacher")]
        public string Faculty_head_id { set; get; }
        public string Faculty_cohead_id { set; get; }
        public Teacher Teacher { set; get; }

        [ForeignKey("FinanceDepartment")]
        public string BudgetApproverId { set; get; }
        public FinanceDepartment FinanceDepartment { set; get; }

    }
}
