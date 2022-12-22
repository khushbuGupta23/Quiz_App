using System;

namespace OnlineExamBLL.CustomBLL
{
    public class SubjectDetails
    {

        public string Subject_name { get; set; }
        public Nullable<decimal> Subject_Marks { get; set; }
        public Nullable<int> User_id { get; set; }
        public int Subject_id { get; set; }
    }
}
