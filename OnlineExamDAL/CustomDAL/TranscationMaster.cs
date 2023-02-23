using OnlineExamDAL.DBContext;
using System;
using OnlineExamBLL.CustomBLL;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamDAL.CustomDAL
{
    class TranscationMaster
    {
        public static string AddQuiz( obj)

        {
            using (var context = new OnlineExamEntities())
            {
                Question Reobj = new Question()
                {
                  
                    Subject_id = obj.Subject_id

                };
                context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
            return "Question Add SUCESSFULLY";
        }

    }
}
