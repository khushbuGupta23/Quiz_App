using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBLL.CustomBLL
{
    public class QuizTDetail
    {
        public int Quiz_Id { get; set; }
        public Nullable<int> Question_Id { get; set; }
        public Nullable<int> Subject_Id { get; set; }
        public string UserName { get; set; }
        public string AnswerGiven { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

    }
}
