using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamBLL.CustomBLL
{
    class QuestionDetail
    {
      
        public string Question_Desc { get; set; }
        public string choice1 { get; set; }
        public string choice2 { get; set; }
        public string choice3 { get; set; }
        public string choice4 { get; set; }
        public string correctAnswer { get; set; }
        public Nullable<int> Subject_id { get; set; }
    }
}
