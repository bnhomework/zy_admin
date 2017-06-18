﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BnAppEntities : AuditableDataContext
    {
        public BnAppEntities()
            : base("name=BnAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_S_Code> T_S_Code { get; set; }
        public virtual DbSet<T_S_Function> T_S_Function { get; set; }
        public virtual DbSet<T_S_Role> T_S_Role { get; set; }
        public virtual DbSet<T_S_Role_Function> T_S_Role_Function { get; set; }
        public virtual DbSet<T_S_User> T_S_User { get; set; }
        public virtual DbSet<T_S_User_Role> T_S_User_Role { get; set; }
        public virtual DbSet<ZY_Booked_Position> ZY_Booked_Position { get; set; }
        public virtual DbSet<ZY_Customer> ZY_Customer { get; set; }
        public virtual DbSet<ZY_Order> ZY_Order { get; set; }
        public virtual DbSet<ZY_Session> ZY_Session { get; set; }
        public virtual DbSet<ZY_Shop> ZY_Shop { get; set; }
        public virtual DbSet<ZY_Shop_Desk> ZY_Shop_Desk { get; set; }
        public virtual DbSet<ZY_Shop_Img> ZY_Shop_Img { get; set; }
        public virtual DbSet<Pay> Pay { get; set; }
    
        public virtual ObjectResult<sp_GetDesks_Result> sp_GetDesks(Nullable<System.Guid> shopId, Nullable<System.DateTime> date)
        {
            var shopIdParameter = shopId.HasValue ?
                new ObjectParameter("shopId", shopId) :
                new ObjectParameter("shopId", typeof(System.Guid));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetDesks_Result>("sp_GetDesks", shopIdParameter, dateParameter);
        }
    
        public virtual ObjectResult<sp_GetDesksForCustomer_Result> sp_GetDesksForCustomer(Nullable<System.Guid> shopId, Nullable<System.DateTime> date)
        {
            var shopIdParameter = shopId.HasValue ?
                new ObjectParameter("shopId", shopId) :
                new ObjectParameter("shopId", typeof(System.Guid));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetDesksForCustomer_Result>("sp_GetDesksForCustomer", shopIdParameter, dateParameter);
        }
    }
}
