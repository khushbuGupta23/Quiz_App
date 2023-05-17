using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBLL.CustomBLL
{
     public class SubjectDetailBLL
    {

        public int Subject_Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectMarks { get; set; }
        public Nullable<int> Role_Id { get; set; }
        public string TotalQues { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> TestCode { get; set; }
    }
}
