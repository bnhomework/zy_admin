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
    
    
    public partial class sp_GetDesksForCustomer_Result
    {
        public System.Guid deskId { get; set; }
        public string deskName { get; set; }
        public string bookedPositions { get; set; }
        public Nullable<System.DateTime> selectedDate { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
