//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CricBook.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTeam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTeam()
        {
            this.tblMatches = new HashSet<tblMatch>();
            this.tblMatches1 = new HashSet<tblMatch>();
            this.tblMatches2 = new HashSet<tblMatch>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Company { get; set; }
        public Nullable<int> Country { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> City { get; set; }
    
        public virtual tblCity tblCity { get; set; }
        public virtual tblCompany tblCompany { get; set; }
        public virtual tblCountry tblCountry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMatch> tblMatches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMatch> tblMatches1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMatch> tblMatches2 { get; set; }
        public virtual tblState tblState { get; set; }
    }
}
