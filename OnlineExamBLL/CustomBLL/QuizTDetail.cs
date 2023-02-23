using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamBLL.CustomBLL
{

    public class QuizDetail
    {
        public int Quiz_id { get; set; }
        public Nullable<int> Question_id { get; set; }
        public Nullable<int> Subject_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public string SelectAnswer { get; set; }
    }
}
