using ManageBLL.CustomBLL;
using ManageDAL.CustomDal;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<HttpResponseMessage> UploadExcel()
        {
            try
            {
                var root = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ExcelPath"]);
                string location = "";
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }
                var reqMesg = Request.GetRequestContext();


                if (Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                var provider = new MultipartFormDataStreamProvider(root);
                var result = await Request.Content.ReadAsMultipartAsync(provider);
                string illegal = provider.FileData[0].Headers.ContentDisposition.FileName;
                string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

                foreach (char c in invalid)
                {
                    illegal = illegal.Replace(c.ToString(), "");
                }

                FileInfo finfo = new FileInfo(illegal);
                string fileType = Path.GetExtension(finfo.Name);

                string filename = DateTime.Now.Ticks.ToString();

                string ExlName = filename + fileType;
                string FileWithPath = string.Format("{0}{1}", filename, fileType);
                location = Path.Combine(root, FileWithPath);
                File.Move(provider.FileData.First().LocalFileName, Path.Combine(root, FileWithPath));
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var package = new ExcelPackage(new FileInfo(location))) 
                {
                    ExcelWorksheet sheet = package.Workbook.Worksheets[0];
                    DataTable dt = new DataTable();
                    dt = GetDataTableFromExcel(location, true);

                    var response = QuestionBankMaster.UploadList(dt);
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
          
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        private DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using (var pck = new ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets[0];
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    if (firstRowCell.Text != "")
                    {
                        tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        try
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                return tbl;
            }
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
