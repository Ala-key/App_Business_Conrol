//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App_List
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopdbEntities : DbContext
    {
        public ShopdbEntities()
            : base("name=ShopdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Deletes_Shop> Deletes_Shop { get; set; }
        public virtual DbSet<Details_Shop> Details_Shop { get; set; }
        public virtual DbSet<Main_Shop> Main_Shop { get; set; }
    }
}
