using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBLL.CustomBLL
{
    public class UserTestDetailBLL
    {
        public string SubjectName { get; set; }
        public int Subject_Id { get; set; }
        public string SubjectName1 { get; set; }
        public string SubjectMarks { get; set; }
        public string TotalQues { get; set; }
        public Nullable<int> MarksQuestion { get; set; }
        public int Quiz_Id { get; set; }
        public Nullable<int> Question_Id { get; set; }
        public Nullable<System.TimeSpan> TimeSpent { get; set; }
        public int User_Id { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Role_Id { get; set; }
    }
}
