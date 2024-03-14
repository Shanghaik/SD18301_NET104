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
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Tên bảng
            builder.ToTable("users");   
            // Khóa chính
            builder.HasKey(x => x.Id);
            // builder.HasKey(x => new { x.Id, x.Dob }); // Khóa hỗn hợp - Ví dụ only
            // Ràng buộc
            builder.Property(p=>p.Address).IsRequired(); // Not null
            // Kiểu dữ liệu cho thuộc tính
            builder.Property(p=>p.UserName).IsRequired().HasColumnName("TenDN").
                HasColumnType("varchar(50)");
            builder.Property(p => p.Name).IsRequired().IsUnicode(true).IsFixedLength().
                HasMaxLength(50); // nvarchar(50) not null
            // builder.Property(p => p.Name).IsRequired().HasColumnType("nvarchar(50)");
            // Đoạn comment trên và đoạn trên nữa có cùng ý nghĩa
        }
    }
}
