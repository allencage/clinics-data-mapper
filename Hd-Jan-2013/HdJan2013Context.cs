namespace Hd_Jan_2013
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HdJan2013Context : DbContext
    {
        public HdJan2013Context()
            : base("name=HdJan2013Context")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Clinics> Clinics { get; set; }
        public virtual DbSet<ClinicSubscriptions> ClinicSubscriptions { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<SubscriptionTypes> SubscriptionTypes { get; set; }
        public virtual DbSet<ZipcodesDK> ZipcodesDK { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areas>()
                .HasMany(e => e.Areas1)
                .WithOptional(e => e.Areas2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Areas>()
                .HasMany(e => e.ZipcodesDK)
                .WithRequired(e => e.Areas)
                .HasForeignKey(e => e.AreaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Areas>()
                .HasMany(e => e.Clinics)
                .WithMany(e => e.Areas)
                .Map(m => m.ToTable("AreaClinics").MapLeftKey("AreaId").MapRightKey("ClinicId"));

            modelBuilder.Entity<Categories>()
                .Property(e => e.DescriptionUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Categories1)
                .WithOptional(e => e.Categories2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Clinics)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("CategoryClinics").MapLeftKey("CategoryId").MapRightKey("ClinicId"));

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Clinics1)
                .WithMany(e => e.Categories1)
                .Map(m => m.ToTable("CategoryClinicsExpanded").MapLeftKey("CategoryId").MapRightKey("ClinicId"));

            modelBuilder.Entity<Clinics>()
                .Property(e => e.VatNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Clinics>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Clinics>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Clinics>()
                .Property(e => e.AdmEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Clinics>()
                .Property(e => e.PublicEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Clinics>()
                .Property(e => e.Homepage)
                .IsUnicode(false);

            modelBuilder.Entity<Clinics>()
                .HasMany(e => e.ClinicSubscriptions)
                .WithRequired(e => e.Clinics)
                .HasForeignKey(e => e.ClinicId);

            modelBuilder.Entity<Clinics>()
                .HasMany(e => e.Persons)
                .WithRequired(e => e.Clinics)
                .HasForeignKey(e => e.ClinicId);

            modelBuilder.Entity<Clinics>()
                .HasMany(e => e.Clinics1)
                .WithMany(e => e.Clinics2)
                .Map(m => m.ToTable("AssociationMembers").MapLeftKey("AssociationId").MapRightKey("ClinicId"));

            modelBuilder.Entity<Events>()
                .Property(e => e.Token)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Persons>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Settings>()
                .Property(e => e.Token)
                .IsUnicode(false);

            modelBuilder.Entity<SubscriptionTypes>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SubscriptionTypes>()
                .HasMany(e => e.ClinicSubscriptions)
                .WithRequired(e => e.SubscriptionTypes)
                .HasForeignKey(e => e.SubscriptionTypeId);

            modelBuilder.Entity<ZipcodesDK>()
                .Property(e => e.Zipcode)
                .IsUnicode(false);
        }
    }
}
