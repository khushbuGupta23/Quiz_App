using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.CustomDAL;
using System.Collections.Generic;
using System.Web.Http;

namespace OnlineExam.Controllers
{
    public class LoginApiController : ApiController
    {
        [HttpPost]
        public string InsertLoginDetails(Logindetail Obj)
        {
            return LoginMaster.InsertLogin(Obj);

        }

        [HttpGet]

        public List<Logindetail> GetLogins()
        {

            return LoginMaster.GetLogins();
        }




    }
}
