//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManageDAL.ContextDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSubjectDetail
    {
        public int Subject_Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectMarks { get; set; }
        public string TotalQues { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> TestCode { get; set; }
    }
}