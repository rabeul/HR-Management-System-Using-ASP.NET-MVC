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
    
    public partial class tblSalary
    {
        public int SalaryCode { get; set; }
        public Nullable<int> EmpCode { get; set; }
        public string Basic { get; set; }
        public string HouseRent { get; set; }
        public string Medical { get; set; }
        public string OtherAllowance { get; set; }
        public string Gross { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
    }
}