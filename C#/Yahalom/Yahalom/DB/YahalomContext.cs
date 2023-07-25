using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Yahalom.DB
{
    public partial class YahalomContext : DbContext
    {
        public YahalomContext()
        {
        }

        public YahalomContext(DbContextOptions<YahalomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<GeneralCategory> GeneralCategories { get; set; }
        public virtual DbSet<GeneralTask> GeneralTasks { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<MyTask> MyTasks { get; set; }
        public virtual DbSet<NewPersonalTask> NewPersonalTasks { get; set; }
        public virtual DbSet<PlaceId> PlaceIds { get; set; }
        public virtual DbSet<SecondCategory> SecondCategories { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierCategory> SupplierCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-379UGQO;Database=Yahalom;Integrated Security=true");
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

                entity.Property(e => e.GroomOrBride)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Groom_Or_Bride");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneralCategory>(entity =>
            {
                entity.ToTable("General_Category");

                entity.Property(e => e.GeneralCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("General_Category_Id");

                entity.Property(e => e.Category)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GeneralTask>(entity =>
            {
                entity.HasKey(e => e.GeneralTasksId);

                entity.ToTable("General_Tasks");

                entity.Property(e => e.GeneralTasksId)
                    .ValueGeneratedNever()
                    .HasColumnName("General_Tasks_Id");

                entity.Property(e => e.GeneralCategoryId).HasColumnName("General_Category_Id");

                entity.Property(e => e.MissionDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Mission_description");

                entity.Property(e => e.SecondCategoryId).HasColumnName("Second_Category_Id");

                entity.HasOne(d => d.GeneralCategory)
                    .WithMany(p => p.GeneralTasks)
                    .HasForeignKey(d => d.GeneralCategoryId)
                    .HasConstraintName("FK_General_Tasks_General_Category");

                entity.HasOne(d => d.SecondCategory)
                    .WithMany(p => p.GeneralTasks)
                    .HasForeignKey(d => d.SecondCategoryId)
                    .HasConstraintName("FK_General_Tasks_Second_Category");
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

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdSuplier).HasColumnName("Id_Suplier");

                entity.Property(e => e.IsPaid).HasColumnName("Is_Paid");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.WorkHoursFrom).HasColumnName("Work_Hours_From");

                entity.Property(e => e.WorkHoursUntill).HasColumnName("Work_Hours_Untill");

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

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdTasks).HasColumnName("ID_Tasks");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.MyTasks)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_My_Tasks_Customer");

                entity.HasOne(d => d.IdTasksNavigation)
                    .WithMany(p => p.MyTasks)
                    .HasForeignKey(d => d.IdTasks)
                    .HasConstraintName("FK_My_Tasks_General_Tasks");

                entity.HasOne(d => d.IdTasks1)
                    .WithMany(p => p.MyTasks)
                    .HasForeignKey(d => d.IdTasks)
                    .HasConstraintName("FK_My_Tasks_New_Personal_Tasks");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.MyTasks)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_My_Tasks_Status");
            });

            modelBuilder.Entity<NewPersonalTask>(entity =>
            {
                entity.HasKey(e => e.NewPersonalTasksId);

                entity.ToTable("New_Personal_Tasks");

                entity.Property(e => e.NewPersonalTasksId)
                    .ValueGeneratedNever()
                    .HasColumnName("New_Personal_Tasks_Id");

                entity.Property(e => e.GeneralCategoryId).HasColumnName("General_Category_id");

                entity.Property(e => e.MissionDescription)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Mission_Description");

                entity.Property(e => e.SecondCategoryId).HasColumnName("Second_Category_Id");

                entity.HasOne(d => d.GeneralCategory)
                    .WithMany(p => p.NewPersonalTasks)
                    .HasForeignKey(d => d.GeneralCategoryId)
                    .HasConstraintName("FK_New_Personal_Tasks_General_Category");

                entity.HasOne(d => d.SecondCategory)
                    .WithMany(p => p.NewPersonalTasks)
                    .HasForeignKey(d => d.SecondCategoryId)
                    .HasConstraintName("FK_New_Personal_Tasks_Second_Category");
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

            modelBuilder.Entity<SecondCategory>(entity =>
            {
                entity.ToTable("Second_Category");

                entity.Property(e => e.SecondCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Second_Category_Id");

                entity.Property(e => e.Details)
                    .HasMaxLength(50)
                    .IsUnicode(false);
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
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("About_Me");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.IdCategory).HasColumnName("ID_Category");

                entity.Property(e => e.IdPlace).HasColumnName("ID_Place");

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
                    .HasConstraintName("FK_Supplier_Supplier_Category");

                entity.HasOne(d => d.IdPlaceNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.IdPlace)
                    .HasConstraintName("FK_Supplier_Place_Id");
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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
