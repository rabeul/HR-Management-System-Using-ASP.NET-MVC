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
    
    public partial class tblBenefit
    {
        public int BenefitCode { get; set; }
        public Nullable<int> EmpCode { get; set; }
        public string BenefitAmount { get; set; }
        public Nullable<System.DateTime> BenefitDate { get; set; }
        public string BenefitType { get; set; }
        public string PreviousNetSalary { get; set; }
        public string NewNetSalary { get; set; }
        public string Gross { get; set; }
        public string Basic { get; set; }
        public string HouseRent { get; set; }
        public string Medical { get; set; }
        public string ConvenceAll { get; set; }
        public string CashIntensive { get; set; }
        public string launceAllowance { get; set; }
        public string otherAllowance { get; set; }
        public string StateStatus { get; set; }
        public Nullable<System.DateTime> BenifitActiveDate { get; set; }
        public string Remarks { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
    }
}
