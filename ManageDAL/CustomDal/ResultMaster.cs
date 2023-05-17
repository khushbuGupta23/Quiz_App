using ManageBLL.CustomBLL;
using ManageDAL.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDAL.CustomDal
{
    public class ResultMaster
    {

        public static List<ResultDetail> GetRecord()
        {
            using (var context = new ApplicationDBEntities())
            {
                List<ResultDetail> obj = new List<ResultDetail>();
                var Data = context.tblResultRecords.ToList();
                obj = Data.Select(x => new ResultDetail
                {
                    Subject_Id = (int)x.Subject_Id,
                    SubjectName = x.SubjectName,
                    UserName = x.UserName,
                    CreationDate = x.CreationDate,
                    SubjectMarks = x.SubjectMarks,
                    TestMarks = x.TestMarks,
                }).ToList();
                return obj;
            }

        }
        public static Results GetRecords()
        {
            Results FinalReport = new Results();
            List<ResultDetail> ResultDetail = new List<ResultDetail>();
            using (var context = new ApplicationDBEntities())
            {

                var Data = context.tblResultRecords.ToList();
                ResultDetail = Data.Select(x => new ResultDetail
                {
                    Subject_Id = (int)x.Subject_Id,
                    SubjectName = x.SubjectName,
                    UserName = x.UserName,
                    CreationDate = x.CreationDate,
                    SubjectMarks = x.SubjectMarks,
                    TestMarks = x.TestMarks,
                }).ToList();
                FinalReport.ResultDetail = ResultDetail;
            }
            return FinalReport;
        }
        public static List<ResultDetail> GetResultbyUser(string UserName)
        {
            using (var context = new ApplicationDBEntities())
            {
                List<ResultDetail> obj = new List<ResultDetail>();

                var Data = context.SP_GetResultByUserName(UserName).ToList();
                obj = Data.Select(x => new ResultDetail
                {
                    Subject_Id = (int)x.Subject_Id,
                    SubjectName = x.SubjectName,
                    UserName = x.UserName,
                    CreationDate = x.CreationDate,
                    SubjectMarks = x.SubjectMarks,
                    TestMarks = x.TestMarks,
                }).ToList();
                AddUserResults(obj);
                return obj;
            }
        }
        public static List<ResultDetail> GetUserResult(int Subject_Id,string UserName)
        {
            using (var context = new ApplicationDBEntities())
            {
                List<ResultDetail> obj = new List<ResultDetail>();

                var Data = context.SP_GetResult(Subject_Id,UserName).ToList();
                obj = Data.Select(x => new ResultDetail
                {
                    Subject_Id = (int)x.Subject_Id,
                    SubjectName=x.SubjectName,
                    UserName = x.UserName,
                    CreationDate = x.CreationDate,
                    SubjectMarks= x.SubjectMarks,
                    TestMarks=x.TestMarks,
                }).ToList();
                AddUserResults(obj);
                return obj;
            }
        }



        public static string AddUserResults(List<ResultDetail> obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                foreach (var data in obj)
                {
                    tblResultRecord Reobj = new tblResultRecord()
                    {
                        Subject_Id = (int)data.Subject_Id,
                        SubjectName = data.SubjectName,
                        UserName = data.UserName,
                        CreationDate = data.CreationDate,
                        SubjectMarks = data.SubjectMarks,
                        TestMarks = data.TestMarks,
                    };
                    context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
            }
            return "Success";
        }
    }
}
