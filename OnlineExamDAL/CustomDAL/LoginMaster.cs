using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExamDAL.CustomDAL
{
    public class LoginMaster
    {
        public static string InsertLogin(Logindetail obj)
        {
            using (var context = new OnlineExamEntities())
            {
                var data = context.Logins.Where(x => x.UserName == obj.UserName).FirstOrDefault();
                if(data == null)
                {
                    Login LogDtl = new Login()
                    {
                        UserName = obj.UserName,
                        password = obj.password,

                    };
                    context.Entry(LogDtl).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
                
            }

            return "Login Successfully";
        }
        public static List<Logindetail> GetLogins()
        {

            using (var context = new OnlineExamEntities())
            {
                List<Logindetail> obj = new List<Logindetail>();

                var data = context.Logins;

                obj = data.Select(x => new Logindetail
                {
                    UserName = x.UserName,
                    password = x.password,
                   
                }).ToList();
                return obj;

            }
        }
    }
}





