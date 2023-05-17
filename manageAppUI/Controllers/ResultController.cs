using ExcelDataReader;
using ManageBLL.CustomBLL;
using ManageDAL.CustomDal;
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
    public class ResultController : ApiController
    {
        [HttpGet]
        //GET api/Result/TestResultList
        public List<ResultDetail> TestResultList()
        {
            return ResultMaster.GetRecord();
        }
        [HttpGet]
        //GET api/Result/TestResultList
        public Results ExcelReport()
        {
            return ResultMaster.GetRecords();
        }
        [HttpGet]
        public List<ResultDetail> GetTestResultByUserName(string UserName)
        {
            return ResultMaster.GetResultbyUser(UserName);
        }

        // api/Result/GetUserTestResult?Subject_Id
        [HttpGet]
        public List<ResultDetail> GetUserTestResult(int Subject_Id, string UserName)
        {
            return ResultMaster.GetUserResult(Subject_Id,UserName);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> UploadExel()
        {
            string response = "";
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                var root = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["ExcelPath"]);
                var provider = new MultipartFormDataStreamProvider(root);
                var result = await Request.Content.ReadAsMultipartAsync(provider);

                if (result.FormData["data"] == null)
                {

                }

                var FileCount = result.FileData.Count;

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
                string File_Name = provider.FileData[0].Headers.ContentDisposition.FileName;
                string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                foreach (char c in invalid)
                {
                    File_Name = File_Name.Replace(c.ToString(), "");
                }
                FileInfo finfo = new FileInfo(File_Name);
                string fileType = Path.GetExtension(finfo.Name);
                string filename = DateTime.Now.Ticks.ToString();
                string ExlName = filename + fileType;
                string FileWithPath = string.Format("{0}{1}", filename, fileType);
                location = Path.Combine(root, FileWithPath);
                System.IO.File.Move(provider.FileData.First().LocalFileName, Path.Combine(root, FileWithPath));
               
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex.Message);

            }

        }
    }
}
