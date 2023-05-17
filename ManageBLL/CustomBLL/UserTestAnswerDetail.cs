using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBLL.CustomBLL
{
    public class UserTestAnswerDetail
    {

        public int ST_Id { get; set; }
        public Nullable<int> Subject_Id { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Question_Id { get; set; }
        public string AnswerGiven { get; set; }
        public string CorrectAnswer { get; set; }
        public Nullable<bool> IsAnswerCorrect { get; set; }
        public Nullable<int> TestMarks { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
