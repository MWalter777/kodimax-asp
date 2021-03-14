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

        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<CANDY> CANDies { get; set; }
        public virtual DbSet<MOVIE> MOVIEs { get; set; }
        public virtual DbSet<SALA> SALAs { get; set; }
        public virtual DbSet<TICKETCANDY> TICKETCANDies { get; set; }
        public virtual DbSet<TICKETMOVIE> TICKETMOVIEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

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

            /* Model DB */

            modelBuilder.Entity<CANDY>()
    .Property(e => e.NAME)
    .IsUnicode(false);

            modelBuilder.Entity<CANDY>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<CANDY>()
                .Property(e => e.PRICE)
                .HasPrecision(8, 2);

            modelBuilder.Entity<CANDY>()
                .Property(e => e.IMAGE)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE>()
                .Property(e => e.TIME)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE>()
                .Property(e => e.IMAGE)
                .IsUnicode(false);

            modelBuilder.Entity<SALA>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SALA>()
                .Property(e => e.PRICE)
                .HasPrecision(8, 2);

            modelBuilder.Entity<TICKETCANDY>()
                .Property(e => e.PAY)
                .HasPrecision(8, 2);

            modelBuilder.Entity<TICKETMOVIE>()
                .Property(e => e.SALA)
                .IsUnicode(false);

            modelBuilder.Entity<TICKETMOVIE>()
                .Property(e => e.TYPE)
                .IsUnicode(false);



        }
    }
}
