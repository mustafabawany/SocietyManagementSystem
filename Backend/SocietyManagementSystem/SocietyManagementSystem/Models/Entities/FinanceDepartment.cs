using System.ComponentModel.DataAnnotations;

namespace SocietyManagementSystem.Models.Entities
{
    public class FinanceDepartment
    {
        [Key]
        public string BudgetApproverId { set; get; }
        
        [Required]
        public string Name { set; get; }
        public string Position { set; get; }

    }
}
