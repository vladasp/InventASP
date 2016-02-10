namespace WebTestInvent
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyModelDB : DbContext
    {
        public MyModelDB()
            : base("name=MyModelDB")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Order_string> Order_strings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.Adress)
                .IsFixedLength();

            modelBuilder.Entity<Good>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Order_string>()
                .Property(e => e.Prise)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order_string>()
                .Property(e => e.Sum)
                .HasPrecision(19, 4);
        }
    }
}
