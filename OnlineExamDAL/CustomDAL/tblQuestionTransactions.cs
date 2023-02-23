namespace OnlineExamDAL.CustomDAL
{
    internal class tblQuestionTransactions
    {
        public tblQuestionTransactions()
        {
        }

        public int Quiz_id { get; set; }
        public int? Question_id { get; set; }
        public int? Subject_id { get; set; }
        public string SelectAnswer { get; set; }
    }
}