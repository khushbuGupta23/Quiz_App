using ManageBLL.CustomBLL;
using ManageDAL.CustomDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace manageAppUI.Controllers
{
    public class MangaeUserController : ApiController
    {
        //Get /api/MangaeUser/GetList
        [HttpGet]
        public List<MangeUserDetail> GetList()
        {
            return MangeUserMaster.GetUser();
        }


        //Post /api/MangaeUser/CreateRecord
        [Route("api/MangaeUser/CreateRecord")]
        public string CreateRecord(MangeUserDetail obj)
        {
            return MangeUserMaster.AddUser(obj);
        }

        //Post /api/MangaeUser/UpdateUsers
        [HttpPost]
        public string UpdateUsers(MangeUserDetail obj)
        {
            return MangeUserMaster.UpdateUser(obj);
        }

        //Delete /api/MangaeUser/Deleteuser?User_Id=
        [HttpDelete]
        public string Deleteuser(int User_Id)
        {
            return MangeUserMaster.DeleteRecord(User_Id);
        }
    }
}
