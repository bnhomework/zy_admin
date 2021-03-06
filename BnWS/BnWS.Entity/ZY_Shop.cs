//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BnWS.Entity
{
    using System;
    using System.Collections.Generic;
    
    using Repository;
    public partial class ZY_Shop:EntityBase,IAuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZY_Shop()
        {
            this.ZY_Shop_Desk = new HashSet<ZY_Shop_Desk>();
            this.ZY_Shop_Img = new HashSet<ZY_Shop_Img>();
        }
    
        public System.Guid ShopId { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public string Address { get; set; }
        public int ShopStatus { get; set; }
        public Nullable<System.Guid> OwnId { get; set; }
        public int VersionNo { get; set; }
        public System.Guid TransactionId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedTime { get; set; }
    
        public virtual T_S_User T_S_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZY_Shop_Desk> ZY_Shop_Desk { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZY_Shop_Img> ZY_Shop_Img { get; set; }
    }
}
