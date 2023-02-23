using System;


namespace OnlineExamBLL.CustomBLL
{
    public class QuestionDetail
    {
        public int Question_id { get; set; }
        public string Question_Desc { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string correctAnswer { get; set; }
        public Nullable<int> Subject_id { get; set; }
        public int Quiz_id { get; set; }
        public object Marks { get; set; }
    }
}
