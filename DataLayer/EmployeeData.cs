namespace WTS.Employees.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeData : DbContext
    {
        public EmployeeData()
            : base("name=EmployeeData")
        {
        }

        public EmployeeData(string ConnectionString)
           : base("name=" + ConnectionString)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Shifts)
                .WithMany(e => e.Employees)
                .Map(m => m.ToTable("Employee_Works_Shift").MapLeftKey("Employee_ID").MapRightKey("Shift_ID"));

            modelBuilder.Entity<Shift>()
                .Property(e => e.Shift_Name)
                .IsUnicode(false);
        }
    }
}
