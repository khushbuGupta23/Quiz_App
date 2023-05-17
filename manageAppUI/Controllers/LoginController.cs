using ManageBLL.CustomBLL;
using ManageDAL;
using ManageDAL.ContextDB;
using ManageDAL.CustomDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace manageAppUI.Controllers
{
    public class LoginController : ApiController
    {

        [HttpPost]
        //api/LoginController/ValidateUser
        public UserDLL ValidateUser(UserDetail obj)
        {
            return UserLogin.ValidateUser(obj);
        }

        [HttpGet]
        public UserDLL AuthUser(string UserName)
        {
            return UserLogin.AuthenticateUser(UserName);
        }
    }
}
