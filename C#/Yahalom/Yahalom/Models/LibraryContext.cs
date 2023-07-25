using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Yahalom.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<MyTask> MyTasks { get; set; }
        public virtual DbSet<PlaceId> PlaceIds { get; set; }
        public virtual DbSet<SecondCtegory> SecondCtegories { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierCategory> SupplierCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Yahalom;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK_Customer_1");

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.DateOfWedding)
                    .HasColumnType("date")
                    .HasColumnName("Date_Of_Wedding");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.IsGroom).HasColumnName("Is_Groom");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.HasKey(e => e.IdInvitation);

                entity.ToTable("Invitation");

                entity.Property(e => e.IdInvitation).HasColumnName("Id_Invitation");

                entity.Property(e => e.DateOfInvitation)
                    .HasColumnType("date")
                    .HasColumnName("Date_Of_Invitation");

                entity.Property(e => e.FinalPrice).HasColumnName("Final_Price");

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdSuplier).HasColumnName("Id_Suplier");

                entity.Property(e => e.IsPaid).HasColumnName("Is_Paid");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.To).HasColumnType("datetime");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Invitations)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Invitation_Customer");

                entity.HasOne(d => d.IdSuplierNavigation)
                    .WithMany(p => p.Invitations)
                    .HasForeignKey(d => d.IdSuplier)
                    .HasConstraintName("FK_Invitation_Supplier");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Invitations)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Invitation_Status");
            });

            modelBuilder.Entity<MyTask>(entity =>
            {
                entity.HasKey(e => e.MyTasksId);

                entity.ToTable("My_Tasks");

                entity.Property(e => e.MyTasksId)
                    .ValueGeneratedNever()
                    .HasColumnName("My_tasks_id");

                entity.Property(e => e.CategoryForTask)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Category_For_task");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IsToWeddingDay).HasColumnName("Is_To_Wedding_Day");

                entity.Property(e => e.MissionDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mission description");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.MyTasks)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_My_Tasks_Customer");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.MyTasks)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_My_Tasks_Status");
            });

            modelBuilder.Entity<PlaceId>(entity =>
            {
                entity.HasKey(e => e.PlaceId1);

                entity.ToTable("Place_Id");

                entity.Property(e => e.PlaceId1)
                    .ValueGeneratedNever()
                    .HasColumnName("Place_ID");

                entity.Property(e => e.Place)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SecondCtegory>(entity =>
            {
                entity.HasKey(e => e.IdSecondCtegory);

                entity.ToTable("Second_Ctegory");

                entity.Property(e => e.IdSecondCtegory)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Second_Ctegory");

                entity.Property(e => e.DescriptionSecondCtegory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Description_Second_Ctegory");

                entity.Property(e => e.IdCategoryLinking).HasColumnName("ID_Category_Linking");

                entity.HasOne(d => d.IdCategoryLinkingNavigation)
                    .WithMany(p => p.SecondCtegories)
                    .HasForeignKey(d => d.IdCategoryLinking)
                    .HasConstraintName("FK_Second_Ctegory_Supplier_Category");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("Status_Id");

                entity.Property(e => e.StatusDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Status_Description");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSuplier);

                entity.ToTable("Supplier");

                entity.Property(e => e.IdSuplier).HasColumnName("ID_Suplier");

                entity.Property(e => e.AboutMe)
                    .HasColumnType("text")
                    .HasColumnName("About_Me");

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Business_Name");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.IdCategory).HasColumnName("ID_Category");

                entity.Property(e => e.IdPlace).HasColumnName("ID_Place");

                entity.Property(e => e.IdSecondSupplierCategory).HasColumnName("Id_Second_Supplier_Category");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PriceFrom).HasColumnName("Price_From");

                entity.Property(e => e.PriceUntill).HasColumnName("Price_Untill");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK_Supplier_Supplier_Category1");

                entity.HasOne(d => d.IdPlaceNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.IdPlace)
                    .HasConstraintName("FK_Supplier_Place_Id");

                entity.HasOne(d => d.IdSecondSupplierCategoryNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.IdSecondSupplierCategory)
                    .HasConstraintName("FK_Supplier_Second_Ctegory");
            });

            modelBuilder.Entity<SupplierCategory>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("Supplier_Category");

                entity.Property(e => e.IdCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Category");

                entity.Property(e => e.Category)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsForGroom).HasColumnName("Is_For_Groom");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
