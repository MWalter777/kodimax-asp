namespace kodimax.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<candy> candies { get; set; }
        public virtual DbSet<movie> movies { get; set; }
        public virtual DbSet<ticket> tickets { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<candy>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<candy>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<candy>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<candy>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<movie>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<movie>()
                .Property(e => e.timemovie)
                .IsUnicode(false);

            modelBuilder.Entity<movie>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<movie>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.sala)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.NOMBRE_ROL)
                .IsUnicode(false);

            modelBuilder.Entity<ROL>()
                .Property(e => e.DESCRIPCION_ROL)
                .IsUnicode(false);


            modelBuilder.Entity<USUARIO>()
              .Property(e => e.EMAIL)
              .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);
        }
    }
}
