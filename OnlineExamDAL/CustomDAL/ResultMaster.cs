using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExamDAL.CustomDAL
{
    public class ResultMaster
    {
        public static List<ResultDetail> GetResults()
        {
            using (var context = new OnlineExamEntities())
            {
                List<ResultDetail> obj = new List<ResultDetail>();
                var Data = context.Results;
                obj = Data.Select(x => new ResultDetail
                {
                    Subject_id = x.Subject_id,
                    TotalMarks = x.TotalMarks,
                    User_id = x.User_id
                }).ToList();
                return obj;
            }
        }
        public static string InsertResult(ResultDetail obj)
        {
            using (var context = new OnlineExamEntities())
            {
                Result ResObj = new Result()
                {
                    Subject_id = obj.Subject_id,
                    User_id = obj.User_id,
                    TotalMarks = obj.TotalMarks

                };
                context.Entry(ResObj).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
            return "Result add Sucessfully";
        }
    }

}
