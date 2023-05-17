using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBLL.CustomBLL
{
    public class Results
    {
        public List<ResultDetail> ResultDetail { get; set; }
    }
    public class ResultDetail
    {

        public int Subject_Id { get; set; }
        public string UserName { get; set; }
        public string SubjectName { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string SubjectMarks { get; set; }
        public Nullable<int> TestMarks { get; set; }
    }
}
