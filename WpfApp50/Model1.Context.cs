﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp50
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Database1Entities : DbContext
    {
        public Database1Entities()
            : base("name=Database1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<client_details> client_details { get; set; }
        public virtual DbSet<client_or_supplier> client_or_supplier { get; set; }
        public virtual DbSet<deleted> deleted { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<employee_type> employee_type { get; set; }
        public virtual DbSet<expense> expense { get; set; }
        public virtual DbSet<final_price> final_price { get; set; }
        public virtual DbSet<kind_product> kind_product { get; set; }
        public virtual DbSet<list_product> list_product { get; set; }
        public virtual DbSet<order> order { get; set; }
        public virtual DbSet<order_details> order_details { get; set; }
        public virtual DbSet<postal_code> postal_code { get; set; }
        public virtual DbSet<shift> shift { get; set; }
        public virtual DbSet<shift_day> shift_day { get; set; }
        public virtual DbSet<shift_time> shift_time { get; set; }
        public virtual DbSet<y_or_n> y_or_n { get; set; }
    }
}
