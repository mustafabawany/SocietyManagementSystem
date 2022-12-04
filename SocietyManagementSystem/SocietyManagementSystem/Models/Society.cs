using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyManagementSystem.Models
{
    public class Society
    {
        public string Announcement { set; get; }
        public int Budget { set; get; }
        public string President_id { set; get; }
        public string Vice_president_id { set; get; }
        public string Treasurer_id { set; get; }
        public string Gs_id { set; get; }
        public string Faculty_head_id { set; get; }
        public string Faculty_cohead_id { set; get; }
        public string BudgetApproverId { set; get; }

    }
}