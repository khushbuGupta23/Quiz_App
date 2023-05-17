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
    public class QuestionBankController : ApiController
    {
        //GET api/QuestionBank/GetQuestionList
        [HttpGet]
        public List<QuestionBankDetail> GetQuestionList()
        {
            return QuestionBankMaster.GetQuestion();
        }
        // api/QuestionBank/GetQuestionbySubject_Id?SUbject_Id
        [HttpPost]
        public List<Question_Detail> GetQuestionbySubject_Id(int Subject_Id)
        {
            return QuestionBankMaster.GetQuestionbyId(Subject_Id);
        }
        // api/QuestionBank/UpdateNoOfQuestion
        [HttpPost]
        public string UpdateNoOfQuestion(SubjectDetailBLL obj)
        {
            return QuestionBankMaster.UpdateNoOfQuestions(obj);
        }

        //POST api/QuestionBank/AddQues
        [Route("api/QuestionBank/AddQues")]
        [HttpPost]

        public string AddQues(QuestionBankDetail obj)
        {
            return QuestionBankMaster.AddQuestion(obj);
        }


        //PUT api/QuestionBank/UpdateQuestion
        [HttpPut]
        public string UpdateQuestion(QuestionBankDetail obj)
        {
            return QuestionBankMaster.EditQuestion(obj);
        }

        // Delete api/QuestionBank/RemoveQuestion?Question_Id
        [HttpDelete]
        public string RemoveQuestion(int Question_Id)
        {
            return QuestionBankMaster.DeleteQuestion(Question_Id);
        }
    }
}
