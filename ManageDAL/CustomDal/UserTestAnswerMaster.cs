using ManageBLL.CustomBLL;
using ManageDAL.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDAL.CustomDal
{
    public class UserTestAnswerMaster
    {
        private static bool IsstausTest;

        public static List<UserTestAnswerDetail> GetUserAnswer()
        {
            using (var context = new ApplicationDBEntities())
            {
                List<UserTestAnswerDetail> obj = new List<UserTestAnswerDetail>();

                var Data = context.tblUserAnswers.ToList();
                obj = Data.Select(x => new UserTestAnswerDetail
                {
                    ST_Id= x.ST_Id,
                    Question_Id = x.Question_Id,
                    UserName=x.UserName,
                    IsAnswerCorrect=x.IsAnswerCorrect,
                    AnswerGiven=x.AnswerGiven,
                    CorrectAnswer= x.CorrectAnswer,
                    Subject_Id = x.Subject_Id,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate
                }).ToList();
                return obj;
            }
        }


        public static string AddQuizAnswer(List<UserTestAnswerDetail> List)
        {
            using (var context = new ApplicationDBEntities())
            {
                foreach (var obj in List)
                {
                   
                        var RD = context.tblUserAnswers.Where(x => x.Question_Id == obj.Question_Id).FirstOrDefault();
                        if (RD != null)


                            RD.IsAnswerCorrect = RD.CorrectAnswer == obj.AnswerGiven ? true : false;
                        RD.Question_Id = obj.Question_Id;
                        RD.Subject_Id = obj.Subject_Id;
                        RD.UserName = obj.UserName;
                        RD.AnswerGiven = obj.AnswerGiven;
                        if (RD.IsAnswerCorrect == true)
                        {
                            RD.TestMarks = 5;
                        }
                        else
                        {
                            RD.TestMarks = 0;
                        }
                        RD.IsActive = true;
                        RD.ModifiedBy = obj.ModifiedBy;
                        RD.ModifiedDate = DateTime.Now;
                        


                        context.Entry(RD).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    
                }
                    return "Answer Update Sucessfully :)";
                
            }
        }
    }
}
