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

        [HttpGet]
        public List<RegisterDetail>GetRegisterDetails(int Registration_id)
        {
            return RegisterMaster.GetRegisterDetails(Registration_id);
        }

        [HttpPost]
        public string AddRegister(RegisterDetail obj)
        {
            return RegisterMaster.AddRegister(obj);
       }
    }
}
