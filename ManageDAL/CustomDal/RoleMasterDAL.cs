using ManageBLL.CustomBLL;
using ManageDAL.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace ManageDAL.CustomDal
{
    public class RoleMasterDAL
    {
        public static List<RoleDetail> GetDetail()
        {
            using (var context = new ApplicationDBEntities())
            {
                List<RoleDetail> obj = new List<RoleDetail>();

                var Data = context.tblRoleMasters.ToList();

                obj = Data.Select(x => new RoleDetail
                {
                    Role_Id = x.Role_Id,
                    Role = x.Role,
                }).ToList();
                return obj;
            }
        }

        public static List<RoleDetail> GetDetails()
        {
            using (var context = new ApplicationDBEntities())

            {
                List<RoleDetail> obj = new List<RoleDetail>();

                var Data = context.tblRoleMasters.Where(x => x.IsActive == true).ToList();
                obj = Data.Select(x => new RoleDetail
                {

                    Role_Id = x.Role_Id,
                    Role = x.Role,
                }).ToList();
                return obj;
            }
        }

        public static List<RoleDetail> GetbyID(int Role_Id)
        {
            using (var context = new ApplicationDBEntities())

            {
                List<RoleDetail> obj = new List<RoleDetail>();

                var Data = context.Sp_GetRoleById(Role_Id).ToList();
                obj = Data.Select(x => new RoleDetail
                {

                    Role_Id = x.Role_Id,
                    Role = x.Role,
                    IsActive = x.IsActive,
                }).ToList();
                return obj;
            }
        }






        public static string AddRole(RoleDetail obj)
        {
            using (var context = new ApplicationDBEntities())
            {
                var check = context.tblRoleMasters.Where(x => x.Role == obj.Role).FirstOrDefault();
               
                if(check!= null)
                {
                    return "Duplicate Value in RoleName :(";
                    
                }
                else
                {
                    tblRoleMaster Reobj = new tblRoleMaster()
                    {
                        Role = obj.Role,
                        IsActive = true,
                        CreatedBy = 1,
                        CreationDate = DateTime.Now,
                    };
                    context.Entry(Reobj).State = System.Data.Entity.EntityState.Added;
                    context.SaveChanges();
                }
            }
            return "Role Add Sucessfully :)";
        
        }

        public static string EditRole(RoleDetail obj)

        {
            using (var context = new ApplicationDBEntities())
            {
                var check = context.tblRoleMasters.Where(x => x.Role == obj.Role && x.Role_Id != obj.Role_Id).FirstOrDefault();
                
                if (check != null)
                {
                    return "Duplicate Value in RoleName   :(";
                }
                else
                {
                    var RD = context.tblRoleMasters.Where(x => x.Role_Id == obj.Role_Id).FirstOrDefault();
                    if (RD != null)
                    {
                        RD.Role = obj.Role;
                        RD.IsActive = true;
                        RD.ModifiedBy = 1;
                        RD.ModifiedDate = DateTime.Now;


                        context.Entry(RD).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    
                }
            }
            return "Role Update SUCESSFULLY";
        }
        //Delete Record
      
        public static string RemoveUser(int Role_Id)
        {
            using (var context = new ApplicationDBEntities())
            {
                var delObj = context.tblRoleMasters.Find(Role_Id);
                context.Entry(delObj).State = System.Data.Entity.EntityState.Deleted;
               
                context.SaveChanges();
            }

            return "delete Sucessfully :|";

        }

    }
}
