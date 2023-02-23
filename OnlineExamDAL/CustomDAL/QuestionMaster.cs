using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Remoting.Contexts;

namespace OnlineExamDAL.CustomDAL
{
    public class QuestionMaster
    {

        public static List<QuestionDetail> GetQuestionDetail()
        {
            using (var context = new OnlineExamEntities())
            {
                List<QuestionDetail> obj = new List<QuestionDetail>();

                var Data = context.Questions.ToList();

                obj = Data.Select(x => new QuestionDetail
                {
                    Question_id = x.Question_id,
                    Question_Desc = x.Question_Desc,
                    A = x.A,
                    B = x.B,
                    C = x.C,
                    D = x.D,
                    correctAnswer = x.correctAnswer,
                    Subject_id = x.Subject_id,
                    Marks = x.Marks
                }).ToList();
                return obj;
            }
        }



        public static List<QuestionDetail> GetQuest(int Subject_id)

        {
            using (var context = new OnlineExamEntities())
            {
                List<QuestionDetail> obj = new List<QuestionDetail>();

                var data = context.Questions.Where(x => x.Subject_id == Subject_id).ToList();
                obj = data.Select(x => new QuestionDetail
                {
                    Question_id = x.Question_id,
                    Question_Desc = x.Question_Desc,
                    A = x.A,
                    B = x.B,
                    C = x.C,
                    D = x.D,
                    correctAnswer = x.correctAnswer,
                    Subject_id = x.Subject_id,
                    Marks = x.Marks

                }).ToList();
                return obj;
            }
        }

        public static string AddQuestion(QuestionDetail obj)

        {
            using (var context = new OnlineExamEntities())
            {
                Question Reobj = new Question()
                {
                    Question_Desc = obj.Question_Desc,
                    A = obj.A,
                    B = obj.B,
                    C = obj.C,
                    D = obj.D,
                    correctAnswer = obj.correctAnswer,
                    Subject_id = obj.Subject_id,
                    Marks = (int?)obj.Marks,



                };
                context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
            return "Question Add SUCESSFULLY";
        }


        public static string EditQuestion(QuestionDetail obj)

        {
            using (var context = new OnlineExamEntities())
            {
                var QuesD = context.Questions.Where(x => x.Question_id == obj.Question_id).FirstOrDefault();
                if (QuesD != null)
                {
                    QuesD.Question_Desc = obj.Question_Desc;
                    QuesD.A = obj.A;
                    QuesD.B = obj.B;
                    QuesD.C = obj.C;
                    QuesD.D = obj.D;
                    QuesD.correctAnswer = obj.correctAnswer;
                    QuesD.Subject_id = obj.Subject_id;
                    QuesD.Marks = (int?)obj.Marks;

                    context.Entry(QuesD).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            return "Question Update SUCESSFULLY";
        }


        public static string DelQuestion(QuestionDetail obj)
        {
            using (var context = new OnlineExamEntities())
            {
                var QuesD = context.Questions.Where(x => x.Question_id == obj.Question_id && x.Subject_id == obj.Subject_id).FirstOrDefault();
                if (QuesD != null)
                {
                    QuesD.Question_Desc = obj.Question_Desc;
                    QuesD.A = obj.A;
                    QuesD.B = obj.B;
                    QuesD.C = obj.C;
                    QuesD.D = obj.D;
                    QuesD.correctAnswer = obj.correctAnswer;
                    QuesD.Subject_id = obj.Subject_id;
                    context.Entry(QuesD).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            return "Question Delete SUCESSFULLY";

        }
        public static string GetAnswer(int[] Question_id)

        {
            using (var db = new OnlineExamEntities())
            {
                var result = db.Questions
                     .AsEnumerable()
                     .Where(y => Question_id.Contains(y.Question_id))
                     .OrderBy(x => { return Array.IndexOf(Question_id, x.Question_id); })
                     .Select(z => z.correctAnswer)
                     .ToArray();
                db.Entry(result).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
            return "Ans";


        }
    }
}

