//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessComponent
{
    using System;
    using System.Collections.Generic;
    
    public partial class SERVICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICE()
        {
            this.RRESV_SERVICE = new HashSet<RRESV_SERVICE>();
            this.SERVICE_REVIEW = new HashSet<SERVICE_REVIEW>();
        }
    
        public int HotelID { get; set; }
        public string SType { get; set; }
        public Nullable<int> SPrice { get; set; }
    
        public virtual HOTEL HOTEL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RRESV_SERVICE> RRESV_SERVICE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICE_REVIEW> SERVICE_REVIEW { get; set; }
    }
}
