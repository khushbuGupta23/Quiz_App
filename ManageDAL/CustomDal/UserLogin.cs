using ManageBLL.CustomBLL;
using ManageDAL.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDAL.CustomDal
{
    public class UserLogin
    {
        public static UserDLL ValidateUser(UserDetail obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                UserDLL lgn = null;
                lgn = new UserDLL
                {
                    User_Id = obj.User_Id,
                    UserName = obj.UserName,
                    Password = obj.Password,
                    Role = obj.Role,

                };
                var chkpwd = context.tblManageUsers.Where(x => x.Password == obj.Password).FirstOrDefault();
                if (chkpwd != null)
                {
                    var userInfo = context.SP_GetUserDetail(obj.UserName, obj.Password).FirstOrDefault();

                    if (userInfo != null)
                    {
                       

                        var data = context.tblManageUsers.Where(x => x.UserName == lgn.UserName && x.Password == lgn.Password);

                        lgn = data.Select(x => new UserDLL
                        {
                            User_Id = x.User_Id,
                            UserName = x.UserName,
                            Password = x.Password,
                            Role = x.Role,



                        }).FirstOrDefault();
                        lgn.IsSuccess = true;
                        lgn.msg = " Login successfully!";
                    }


                    else
                    {
                        lgn = new UserDLL
                        {
                            IsSuccess = false,
                            msg = "User Does Not Exist! Please Renter User !"
                        };
                    }



                }
                else
                {

                    lgn = new UserDLL
                    {
                        IsSuccess = false,
                        msg = "Please Enter Correct Password!"
                    };

                }

                return lgn;
            }
           
        }


        public static UserDLL AuthenticateUser(string userName)
        {
            using (var Context = new ApplicationDBEntities())
            {
                var data = Context.SP_GetUserNameDetail(userName).FirstOrDefault();
                UserDLL ModelData = new UserDLL();
                if (data == null)
                {
                    return ModelData;
                }
                else
                {
                    ModelData.User_Id = data.User_Id;
                    ModelData.UserName = data.UserName;
                    ModelData.Role = data.Role;
                    ModelData.Password = data.Password;
                    ModelData.IsActive = data.IsActive;

                    return ModelData;
                }
            }

        }
    }
}
