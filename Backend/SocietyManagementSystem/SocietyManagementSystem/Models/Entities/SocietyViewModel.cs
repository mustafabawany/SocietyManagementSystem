using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocietyManagementSystem.Models.Entities
{
    public class SocietyViewModel
    {
        public string? Announcement { set; get; }
        public int Budget { set; get; }
        public string? President_id { set; get; }
        public string? Vice_president_id { set; get; }
        public string? Treasurer_id { set; get; }
        public string? Gs_id { set; get; }
        public string Faculty_head_id { set; get; }
        public string Faculty_cohead_id { set; get; }
        public string BudgetApproverId { set; get; }
    }
}
