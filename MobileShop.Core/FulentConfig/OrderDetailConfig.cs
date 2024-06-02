using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Core.FulentConfig
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.OrderId });
            builder.HasOne(x => x.Product).WithMany(pc => pc.OrderDetail).HasForeignKey(pc => pc.ProductId);
            builder.HasOne(x => x.Order).WithMany(pc => pc.OrderDetail).HasForeignKey(pc => pc.OrderId);
        }
    }
}
