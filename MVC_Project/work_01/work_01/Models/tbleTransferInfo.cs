//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace work_01.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbleTransferInfo
    {
        public int TRCode { get; set; }
        public Nullable<System.DateTime> TRDate { get; set; }
        public Nullable<int> OldDeptCode { get; set; }
        public Nullable<int> NewDeptCode { get; set; }
        public Nullable<int> OldDesignationCode { get; set; }
        public Nullable<int> NewDesigtnationCode { get; set; }
        public Nullable<int> OldSecCode { get; set; }
        public Nullable<int> NewSecCode { get; set; }
        public Nullable<int> OldDivCode { get; set; }
        public Nullable<int> NewDivCode { get; set; }
        public Nullable<System.DateTime> TrActivateDate { get; set; }
        public Nullable<int> EmpCode { get; set; }
        public string StateStatus { get; set; }
        public string Remarks { get; set; }
        public string EmpName { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
    }
}
