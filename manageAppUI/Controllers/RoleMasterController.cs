﻿using ManageBLL.CustomBLL;
using ManageDAL.CustomDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace manageAppUI.Controllers
{
    public class RoleMasterController : ApiController
    {
        //GET api/RoleMaster/GetList
        [HttpGet]
        public List<RoleDetail> GetList()
        {
            return RoleMasterDAL.GetDetail();
        }
        [HttpPost]
        public List<RoleDetail> GetRoleById()
        {
            return RoleMasterDAL.GetDetails();
        }


        //GET api/RoleMaster/GetRoleById?Role_Id

        [HttpPost]

        public List<RoleDetail> GetRoleBYId(int Role_Id)
        {
            return RoleMasterDAL.GetbyID(Role_Id);
        }


        //POST api/RoleMaster/ADDRole
        [Route("api/RoleMaster/ADDRole")]

        [HttpPost]
        public string ADDRole(RoleDetail obj)
        {
            return RoleMasterDAL.AddRole(obj);
        }

        //PUT api/RoleMaster/UpdateRole
        [HttpPut]
        public string UpdateRole(RoleDetail obj)
        {
            return RoleMasterDAL.EditRole(obj);
        }

        // Delete api/RoleMaster/RemoveRole?Role_Id=
        [HttpDelete]
        public string RemoveRole(int Role_Id)
        {
            return RoleMasterDAL.RemoveUser(Role_Id);
        }



        
    }

}
