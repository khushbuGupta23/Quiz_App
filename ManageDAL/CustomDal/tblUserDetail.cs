using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageDAL.CustomDal
{
     public class tblUserDetail
    {
        public int User_Id { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Role_Id { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsSuccess { get; set; }
        public string msg { get; set; }
    }
}
