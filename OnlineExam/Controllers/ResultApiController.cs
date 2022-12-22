using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.CustomDAL;
using System.Collections.Generic;
using System.Web.Http;

namespace OnlineExam.Controllers
{
    public class ResultApiController : ApiController
    {
        [HttpGet]
        public List<ResultDetail> GetResultDetails()
        {
            return ResultMaster.GetResults();
        }

        [HttpPost]
        public string GetResultDetail(ResultDetail Obj)
        {
            return ResultMaster.InsertResult(Obj);

        }
    }
}
