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
    public class SanPhamConfig : IEntityTypeConfiguration<SanPham>
    {
        void IEntityTypeConfiguration<SanPham>.Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
