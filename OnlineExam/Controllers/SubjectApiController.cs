using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.CustomDAL;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineExam.Controllers
{
    [EnableCorsAttribute("*","*","*")]
    public class SubjectApiController : ApiController
    {
        [HttpPost]
        public string GetSubjectDetails(SubjectDetails Obj)
        {
            return SubjectMaster.InsertSubject(Obj);

        }

        [HttpGet]

        public List<SubjectDetails> GetSubjectDetail()
        {

            return SubjectMaster.GetSubject();
        }
    }
}
