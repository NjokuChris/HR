//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class job_title
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public job_title()
        {
            this.employees = new HashSet<employee>();
        }
    
        public int job_title_id { get; set; }
        public string job_title1 { get; set; }
        public string job_title_code { get; set; }
        public Nullable<int> job_class_id { get; set; }
        public Nullable<int> department_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> supervisor_type_id { get; set; }
    
        public virtual company company { get; set; }
        public virtual department department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employees { get; set; }
        public virtual job_class job_class { get; set; }
        public virtual job_class job_class1 { get; set; }
    }
}
