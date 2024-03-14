using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configurations
{
    internal class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(x => x.Id);
            // Các thuộc tính tự config
            // Khóa ngoại
            builder.HasOne(p => p.User).WithMany(p => p.HoaDons).HasForeignKey(p => p.UserID)
                .HasConstraintName("FK_HD_KH");
            // Tạo 1 khóa ngoại nối từ bảng Hóa đơn tới bảng user với tên khóa ngoại là
            // FK_HD_KH và cột liên kết là UserID
        }
    }
}
