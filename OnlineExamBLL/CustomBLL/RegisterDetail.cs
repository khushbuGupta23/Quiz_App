using System;

namespace OnlineExamBLL.CustomBLL
{
    public class RegisterDetail
    {
        public int Registration_id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Nullable<decimal> Phone_no { get; set; }
        public string P_Address { get; set; }
    }
}
