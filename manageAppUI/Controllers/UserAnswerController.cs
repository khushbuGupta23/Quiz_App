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
    public class UserAnswerController : ApiController
    {
        [HttpGet]
        public List<UserTestAnswerDetail> GetUsertestAnswer()
        {
            return UserTestAnswerMaster.GetUserAnswer();
        }

        [Route("api/UserAnswer/updateUserAnswer")]
        [HttpPut]

        public string updateUserAns( List<UserTestAnswerDetail> obj)
        {
            return UserTestAnswerMaster.AddQuizAnswer(obj);
        }


    }
}
