﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiqPayServer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LiqPayDBEntities : DbContext
    {
        public LiqPayDBEntities()
            : base("name=LiqPayDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<rl_feedback_data> rl_feedback_data { get; set; }
        public virtual DbSet<rl_liqpay_donate_info> rl_liqpay_donate_info { get; set; }
        public virtual DbSet<rl_subscribers> rl_subscribers { get; set; }
        public virtual DbSet<Errors> Errors { get; set; }
    }
}
