using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.CustomDAL;
using OnlineExamDAL.DBContext;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineExam.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class SubjectApiController : ApiController
    {
        [HttpGet]

        public List<SubjectDetails> GetSubjectDetail()
        {

            return SubjectMaster.GetSubject();
        }

        [HttpPost]
        public string GetSubjectDetails(SubjectDetails Obj)
        {
            return SubjectMaster.InsertSubject(Obj);

        }

       
        [HttpPut]
        public string UpdateSubject(SubjectDetail obj)
        {
            return SubjectMaster.EditSubject(obj);
        }
    }
}