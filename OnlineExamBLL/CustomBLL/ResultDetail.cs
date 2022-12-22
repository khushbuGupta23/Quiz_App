using System;

namespace OnlineExamBLL.CustomBLL
{
    public class ResultDetail
    {
        public int ResultId { get; set; }
        public Nullable<int> Subject_id { get; set; }
        public Nullable<int> User_id { get; set; }
        public Nullable<double> TotalMarks { get; set; }
    }
}
