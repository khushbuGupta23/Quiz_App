using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExamDAL.CustomDAL
{
    public class RegisterMaster
    {
        public static List<RegisterDetail> GetRegisterdetail()
        {
            using (var context = new OnlineExamEntities())
            {
                List<RegisterDetail> obj = new List<RegisterDetail>();

                var Data = context.Registers;

                obj = Data.Select(x => new RegisterDetail
                {
                    Registration_id=x.Registration_id,
                    UserName = x.UserName,
                    Email = x.Email,
                    Phone_no = x.Phone_no,
                    P_Address = x.P_Address

                }).ToList();
                return obj;
            }
        }

        public static List<RegisterDetail> GetRegisterDetails(int Registration_id)
        {
            using (var context = new OnlineExamEntities())
            {
                List<RegisterDetail> registerDetails = new List<RegisterDetail>();
                var data = context.Registers;
                registerDetails = data.Select(x => new  RegisterDetail
                {
                    Registration_id =x.Registration_id,
                    UserName=x.UserName,
                    Email= x.Email,
                    Phone_no=x.Phone_no,
                    P_Address=x.P_Address
                }).ToList();
                return registerDetails;
            }
        }

        public static string AddRegister(RegisterDetail obj)
        {
            using (var context = new OnlineExamEntities())
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
