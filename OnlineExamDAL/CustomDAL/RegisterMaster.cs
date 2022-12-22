using OnlineExamBLL.CustomBLL;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExamDAL.CustomDAL
{
    public class RegisterMaster
    {
        public static List<RegisterDetail> GetRegisterdetail()
        {
            using (var context = new OnlineExamEntities1())
            {
                List<RegisterDetail> obj = new List<RegisterDetail>();

                var Data = context.Registers;

                obj = Data.Select(x => new RegisterDetail
                {
                    UserName = x.UserName,
                    Email = x.Email,
                    Phone_no = x.Phone_no,
                    P_Address = x.P_Address

                }).ToList();
                return obj;
            }
        }

        public static string AddRegister(RegisterDetail obj)
        {
            using (var context = new OnlineExamEntities1())
            {
                Register Reobj = new Register()
                {
                    UserName = obj.UserName,
                    Email = obj.Email,
                    Phone_no = (int)obj.Phone_no,
                    P_Address = obj.P_Address

                };
                context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
            return "REGISTRATION SUCESSFULLY";
        }
    }
}
