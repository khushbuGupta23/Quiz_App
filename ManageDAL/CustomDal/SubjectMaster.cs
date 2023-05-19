
using ManageBLL.CustomBLL;
using ManageDAL.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDAL.CustomDal
{
    public class SubjectMaster
    {

        public static List<SubjectDetailBLL> GetSubject()
        {
            using (var context = new ApplicationDBEntities())
            {
                List<SubjectDetailBLL> obj = new List<SubjectDetailBLL>();
                var data = context.tblSubjectDetails.ToList();
                obj = data.Select(x => new SubjectDetailBLL
                {
                    Subject_Id = x.Subject_Id,
                    SubjectName = x.SubjectName,
                    SubjectMarks = x.SubjectMarks,
                    IsActive = x.IsActive,
                    TotalQues = x.TotalQues,
                    CreatedBy = x.CreatedBy,
                    CreationDate = x.CreationDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate,

                }).ToList();
                return obj;
            }
        }

        public static List<SubjectDetailBLL> GetSubject(int Subject_Id, string UserName)
        {
            using (var context = new ApplicationDBEntities())
            {
                bool stausTest;
                var UserChk = context.SP_GetResult(Subject_Id, UserName).FirstOrDefault();
                
                if (UserChk != null)
                {
                    stausTest = false;
                }
                else
                {
                    stausTest = true;

                }
               
                    List<SubjectDetailBLL> obj = new List<SubjectDetailBLL>();
                    var data = context.sp_GetStudentTestDetails(Subject_Id).ToList();
                    obj = data.Select(x => new SubjectDetailBLL
                    {
                        Subject_Id = x.Subject_Id,
                        SubjectName = x.SubjectName,
                        SubjectMarks = x.SubjectMarks,
                        TestCode = stausTest

                    }).ToList();

                    return obj;
                
               
            }
        }
        public static string AddSubject(SubjectDetailBLL obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                var check = context.tblSubjectDetails.Where(x => x.SubjectName == obj.SubjectName).FirstOrDefault();

                if (check != null)
                {
                    return "Duplicate Value in Subject Name :(";
                }
                else
                {
                    tblSubjectDetail Reobj = new tblSubjectDetail()
                    {
                        SubjectName = obj.SubjectName,
                        SubjectMarks = obj.SubjectMarks,
                       
                        TotalQues = obj.TotalQues,
                        IsActive = true,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now,
                    };
                    context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
            }
            return "Subject Add Sucessfully :)";

        }
        


        public static string UpdateSubject(SubjectDetailBLL obj)
        {
            using (var context= new ApplicationDBEntities())
            { 

                var check = context.tblSubjectDetails.Where(x => x.SubjectName == obj.SubjectName && x.Subject_Id != obj.Subject_Id).FirstOrDefault();
                if(check!= null)
                {
                    return "Duplicate Value in SubjectName   :( ";
                }
                else
                {
                    var SD = context.tblSubjectDetails.Where(x => x.Subject_Id == obj.Subject_Id).FirstOrDefault();
                    if(SD != null)
                    {
                        SD.SubjectName = obj.SubjectName;
                        SD.SubjectMarks = obj.SubjectMarks;
                      
                        SD.TotalQues = obj.TotalQues;
                        SD.IsActive = true;
                        SD.ModifiedBy = 1;
                        SD.ModifiedDate = DateTime.Now;

                        context.Entry(SD).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            return "Subject Updated Successfully";
        }


        public static string RemoveSub(int Subject_Id)
        {
            using (var context= new ApplicationDBEntities())
            {
                var Delobj = context.tblSubjectDetails.Find(Subject_Id);
                context.tblSubjectDetails.Remove(Delobj);
                context.SaveChanges();
            }

            return "deleted Sucessfully :|";
        }

    }
}
