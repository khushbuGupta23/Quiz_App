using ManageBLL.CustomBLL;
using ManageDAL.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDAL.CustomDal
{
    public class QuestionBankMaster
    {
        public static List<QuestionBankDetail>GetQuestion()
        {
            using (var context = new ApplicationDBEntities())
            {
                List<QuestionBankDetail> obj = new List<QuestionBankDetail>();

                var Data = context.tblQuestionBanks.ToList();
                obj = Data.Select(x => new QuestionBankDetail
                {
                    Question_Id = x.Question_Id,
                    Question = x.Question,
                    Answer1 = x.Answer1,
                    Answer2 = x.Answer2,
                    Answer3 = x.Answer3,
                    Answer4 = x.Answer4,
                    AnswerKey= x.AnswerKey,
                    Subject_Id = x.Subject_Id,
                    IsActive = x.IsActive,
                    CreatedBy= x.CreatedBy,
                    CreationDate= x.CreationDate,
                    ModifiedBy= x.ModifiedBy,
                    ModifiedDate= x.ModifiedDate
                }).ToList();
                return obj;
            }
        }

        public static List<Question_Detail> GetQuestionbyId(int Subject_Id)
        {
            using (var context = new ApplicationDBEntities())
            {
               
                List<Question_Detail> obj = new List<Question_Detail>();
                var data = context.Sp_Questionbank_Detail(Subject_Id).ToList();

                obj = data.Select(x => new Question_Detail
                {
                    Question_Id = (int)x.Question_Id,
                    Question = x.Question,
                    Answer1 = x.Answer1,
                    Answer2 = x.Answer2,
                    Answer3 = x.Answer3,
                    Answer4 = x.Answer4,
                    AnswerKey = x.AnswerKey,
                    Subject_Id = x.Subject_Id ,
                    SubjectName = x.SubjectName,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreationDate = x.CreationDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate

                }).ToList();
                AddQuestionsIntoUserAnswer(obj);
                return obj;
                
            }
        }

        public static string AddQuestionsIntoUserAnswer(List<Question_Detail> obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                foreach(var data in obj)
                {
                    tblUserAnswer Reobj = new tblUserAnswer()
                    {
                        Question_Id = data.Question_Id,
                        CorrectAnswer = data.AnswerKey,
                        AnswerGiven = null,
                        IsAnswerCorrect = false,
                        Subject_Id = data.Subject_Id,
                        IsActive = true,
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                    };
                    context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
            }
            return "Success";
        }

        public static string AddQuestion(QuestionBankDetail obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                tblQuestionBank Reobj = new tblQuestionBank()
                {
                    Question = obj.Question,
                    Answer1 = obj.Answer1,
                    Answer2 = obj.Answer2,
                    Answer3 = obj.Answer3,
                    Answer4 = obj.Answer4,
                    AnswerKey= obj.AnswerKey,
                    Subject_Id= obj.Subject_Id,
                    IsActive = true,
                    CreatedBy = obj.CreatedBy,
                    CreationDate = DateTime.Now,

                };
                context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
               
                context.SaveChanges();
            }
            return "Question Add Sucessfully :)";
        }

        public static string UpdateNoOfQuestions(SubjectDetailBLL obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                var SD = context.tblSubjectDetails.Where(x => x.Subject_Id == obj.Subject_Id).FirstOrDefault();
                if (SD != null)
                {
                    SD.SubjectMarks = obj.SubjectMarks+ obj.SubjectMarks;
                    SD.TotalQues = obj.TotalQues+1;

                    context.Entry(SD).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            return "Success";
        }

        public static  string EditQuestion(QuestionBankDetail obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                var RD = context.tblQuestionBanks.Where(x => x.Question_Id == obj.Question_Id).FirstOrDefault();
                if (RD != null)
                {
                    RD.Question = obj.Question;
                    RD.Answer1 = obj.Answer1;
                    RD.Answer2 = obj.Answer2;
                    RD.Answer3 = obj.Answer3;
                    RD.Answer4 = obj.Answer4;
                    RD.AnswerKey = obj.AnswerKey;
                    RD.Subject_Id = obj.Subject_Id;
                    RD.IsActive = true;
                    RD.ModifiedBy = obj.ModifiedBy;
                    RD.ModifiedDate = DateTime.Now;


                    context.Entry(RD).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }

                return "Question Update SUCESSFULLY";
            }
        }


        public static string DeleteQuestion(int Question_Id)
        {
            using (var context = new ApplicationDBEntities())
            {
                var DelObj = context.tblQuestionBanks.Find(Question_Id);
                context.tblQuestionBanks.Remove(DelObj);
                context.SaveChanges();
            }
            return "Delete Succesfully";
        }
       
    }
}
