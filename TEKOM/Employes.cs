namespace TEKOM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Employes : DbContext
    {
        public Employes()
            : base("name=Employes")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.SurName)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsFixedLength();
        }
    }
}
