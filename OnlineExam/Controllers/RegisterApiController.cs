using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.CustomDAL;
using System.Collections.Generic;
using System.Web.Http;

namespace OnlineExam.Controllers
{
    public class RegisterApiController : ApiController
    {
        [HttpGet]

        public List<RegisterDetail> GetRegister()
        {
            return RegisterMaster.GetRegisterdetail();
        }


        [HttpPost]
        public string AddRegister(RegisterDetail obj)
        {
            return RegisterMaster.AddRegister(obj);
       }
    }
}
