using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBLL.CustomBLL
{
    public class UserDetail_Result
    {

        public int User_Id { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Role_Id { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
