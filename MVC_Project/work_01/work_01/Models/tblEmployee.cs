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
    
    public partial class tblEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmployee()
        {
            this.tblAttendences = new HashSet<tblAttendence>();
            this.tblBenefits = new HashSet<tblBenefit>();
            this.tbleTransferInfoes = new HashSet<tbleTransferInfo>();
            this.tblSalaries = new HashSet<tblSalary>();
        }
    
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string NID { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<int> DeptCode { get; set; }
        public Nullable<int> DesigCode { get; set; }
        public Nullable<int> SecCode { get; set; }
        public Nullable<int> DivCode { get; set; }
        public Nullable<int> EmpTypeCode { get; set; }
        public string CurrentSalary { get; set; }
        public string AccNo { get; set; }
        public string BankName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAttendence> tblAttendences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBenefit> tblBenefits { get; set; }
        public virtual tblDepartment tblDepartment { get; set; }
        public virtual tblDesignation tblDesignation { get; set; }
        public virtual tblDivision tblDivision { get; set; }
        public virtual tblEmployeeType tblEmployeeType { get; set; }
        public virtual tblSection tblSection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbleTransferInfo> tbleTransferInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSalary> tblSalaries { get; set; }
    }
}
