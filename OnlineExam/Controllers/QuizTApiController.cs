using OnlineExamBLL.CustomBLL;
using OnlineExamDAL.CustomDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineExam.Controllers
{
    public class QuizTApiController : ApiController
    {
        [HttpPost]
        public string InsertQuiz(QuizDetail quizDetail)
        {
            return QuizTMaster.AddQuiz(quizDetail);
        }


        [HttpGet]
        public List<QuizDetail> GetQues(int Question_id)
        {
            return QuizTMaster.GetQuiz(Question_id);

        }
    }
}
