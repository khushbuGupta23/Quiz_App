using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineExamBLL.CustomBLL
{
    public class ResultDetail
    {
        public int ResultId { get; set; }
        [ForeignKey("Subject_id")]
        public Nullable<int> Subject_id { get; set; }
        [ForeignKey("Registration_id")]
        public Nullable<int> Registration_id { get; set; }
        public Nullable<double> TotalMarks { get; set; }
    }
}
