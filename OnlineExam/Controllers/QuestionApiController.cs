using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.CustomDAL;
using OnlineExamDAL.DBContext;
using System.Collections.Generic;
using System.Web.Http;
namespace OnlineExam.Controllers
{
    public class QuestionApiController : ApiController
    {
        [HttpGet]

        public List<QuestionDetail> GetQuestion()
        {
            return QuestionMaster.GetQuestionDetail();
        }

        [HttpGet]
        public List<QuestionDetail> GetQues(int Subject_id)
        {
            return QuestionMaster.GetQuest(Subject_id);

        }
       

        [HttpPost]
        public string InsertQuestion(QuestionDetail obj)
       {
            return QuestionMaster.AddQuestion(obj);
        }

        [HttpPut]
        public string UpdateQuestion(QuestionDetail obj)
        {
            return QuestionMaster.EditQuestion(obj);
        }

        [HttpDelete]
        public string DeleteQuestion(QuestionDetail obj)
        {
            return QuestionMaster.DelQuestion(obj);
        }

        [HttpPost]
        [Route("api/Answers")]
        public string GetAnswers(int[] Question_id)
        {
            return QuestionMaster.GetAnswer(Question_id);
        }


    }
}