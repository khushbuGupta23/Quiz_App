//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExamDAL.DBContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public int Question_id { get; set; }
        public string Question_Desc { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string correctAnswer { get; set; }
        public Nullable<int> Subject_id { get; set; }
        public Nullable<int> Marks { get; set; }
    }
}
