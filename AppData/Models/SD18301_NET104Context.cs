using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppData.Models
{
    public partial class SD18301_NET104Context : DbContext
    {
        public SD18301_NET104Context()
        {
        }

        public SD18301_NET104Context(DbContextOptions<SD18301_NET104Context> options)
            : base(options)
        {
        }
        // Thêm DBSet vào 
        public DbSet<User> Users { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SHANGHAIK;Database=SD18301_NET104;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
