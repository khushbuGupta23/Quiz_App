using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamDAL.CustomDAL
{
    public class QuizTMaster
    {
        public static string AddQuiz(QuizDetail quizDetail)
        {
            using (var context = new OnlineExamEntities())
            {
                tblQuestionTransaction QTb = new tblQuestionTransaction()
                {
                    Quiz_id = quizDetail.Quiz_id,
                    Question_id = quizDetail.Question_id,
                    Subject_id = quizDetail.Subject_id,
                    SelectAnswer = quizDetail.SelectAnswer
                };
                context.Entry(QTb).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
            return "QuesT";

        }



        public static List<QuizDetail> GetQuiz(int Question_id)
     
        {
            using (var context = new OnlineExamEntities())
            {
                List<QuizDetail> obj = new List<QuizDetail>();

                var data = context.tblQuestionTransactions.Where(x => x.Question_id == Question_id);
                obj = data.Select(x => new QuizDetail

                {
                    Quiz_id = x.Quiz_id,
                    Question_id = x.Question_id,
                    Subject_id =x.Subject_id,
                    SelectAnswer = x.SelectAnswer
                }).ToList();
                return obj;
            }
            

        }
    }

   
}