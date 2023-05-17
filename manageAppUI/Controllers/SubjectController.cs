
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
    public class SubjectController : ApiController
    {
        //GET api/Subject/GetList

        [HttpGet]
        public List<SubjectDetailBLL> GetList()
        {
            return SubjectMaster.GetSubject();
        }
        [HttpGet]
        public List<SubjectDetailBLL> GetLists(int Subject_Id, string UserName)
        {
            return SubjectMaster.GetSubject(Subject_Id, UserName);
        }


        //POST api/Subject/AddSub
        [Route("api/Subject/AddSub")]

        [HttpPost]
        public string AddSub(SubjectDetailBLL obj)
        {
            return SubjectMaster.AddSubject(obj);
        }

        //Post api/Subject/UpdateSub
        [HttpPost]
        public string UpdateSub(SubjectDetailBLL obj)
        {
            return SubjectMaster.UpdateSubject(obj);
        }


        //Delete api/Subject/DeleteSub?Subject_Id
        [HttpDelete]
        public string DeleteSub(int Subject_Id)
        {
            return SubjectMaster.RemoveSub(Subject_Id);
        }


    }
}
