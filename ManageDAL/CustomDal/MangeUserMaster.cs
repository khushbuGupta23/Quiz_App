using ManageBLL.CustomBLL;
using ManageDAL.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDAL.CustomDal
{
    public class MangeUserMaster
    {
        public static List<MangeUserDetail> GetUser()
        {
            using(var context =new ApplicationDBEntities())
            {
                List<MangeUserDetail> obj = new List<MangeUserDetail>();
                var data = context.tblManageUsers.ToList();
                obj = data.Select(x => new MangeUserDetail
                {
                    User_Id = x.User_Id,
                    UserName = x.UserName,
                    Role =  x.Role,
                    Mobile_Number= x.Mobile_Number,
                    Email = x.Email,
                    Password = x.Password,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate

                }).ToList();
                return obj;
            }
            
        }


        //CreateRecord
        public static  string AddUser(MangeUserDetail obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                var check = context.tblManageUsers.Where(x => x.UserName == obj.UserName).FirstOrDefault();

                if (check != null)
                {
                    return "Duplicate Vaue in UserName :(";

                }
                else
                {
                    tblManageUser Reobj = new tblManageUser()
                    {
                        UserName = obj.UserName,
                        Role = obj.Role,
                        Mobile_Number = obj.Mobile_Number,
                        Email = obj.Email,
                        Password = obj.Password,
                        IsActive = true,
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = null,
                        ModifiedDate = null,

                    };

                    context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }

            }
            return "User Add Sucessfully :)";
        }


        //Update Record
        public static string UpdateUser(MangeUserDetail obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                var check = context.tblManageUsers.Where(x => x.UserName == obj.UserName && x.User_Id != obj.User_Id).FirstOrDefault();

                if (check != null)
                {
                    return "Duplicate Value in UserName   :(";
                }
                else
                {
                    var UD = context.tblManageUsers.Where(x => x.User_Id == obj.User_Id).FirstOrDefault();
                    if (UD != null)
                    {
                        UD.UserName = obj.UserName;
                        UD.Role = obj.Role;
                        UD.Mobile_Number = obj.Mobile_Number;
                        UD.Email = obj.Email;
                        UD.Password = obj.Password;
                        UD.IsActive = obj.IsActive;
                        UD.CreatedBy = obj.CreatedBy;
                        UD.CreatedDate = obj.CreatedDate;
                        UD.ModifiedBy = 1;
                        UD.ModifiedDate = DateTime.Now;
                        context.Entry(UD).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            return "Upadate Successfully";
        }

        //Delete Record
        public static string DeleteRecord(int User_Id)
        {
            using(var context=new ApplicationDBEntities())
            {
                var Del = context.tblManageUsers.Find(User_Id);
                context.Entry(Del).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

            }
            return "Delete SuccessFully";
        }


    }
}
