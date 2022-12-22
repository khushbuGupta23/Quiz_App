using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExamDAL.CustomDAL
{
    public class SubjectMaster
    {
        public static string InsertSubject(SubjectDetails obj)
        {
            using (var context = new OnlineExamEntities())
            {
                var subjectDtl = context.SubjectDetails.Where(x => x.Subject_name == obj.Subject_name).FirstOrDefault();
                if(subjectDtl == null)
                {
                    SubjectDetail SubDtl = new SubjectDetail()
                    {
                        Subject_id = obj.Subject_id,
                        Subject_name = obj.Subject_name,
                        Subject_Marks = obj.Subject_Marks,
                        User_id = obj.User_id
                    };
                    context.Entry(SubDtl).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    return "invalid"; 
                }
               
            } 

            return "Success: Subject not Added Successfully";
        }


        public static List<SubjectDetails> GetSubject()
        {
            using (var context = new OnlineExamEntities())
            {
                List<SubjectDetails> obj = new List<SubjectDetails>();

                var data = context.SubjectDetails;

                obj = data.Select(x => new SubjectDetails
                {
                    Subject_name = x.Subject_name,
                    Subject_Marks = x.Subject_Marks,
                    User_id = x.User_id

                }).ToList();
                return obj;
            }
        }
    }
}
