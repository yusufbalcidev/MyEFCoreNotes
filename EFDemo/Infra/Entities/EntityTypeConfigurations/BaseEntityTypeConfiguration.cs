using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDemo.Infra.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDemo.Infra.Entities.EntityTypeConfigurations
{
    public class BaseEntityTypeConfiguration<TEntity> :
        IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity //BaseEntity den turemis tum classlari getirir
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreatedDate)
            .HasColumnType("datetime2");
            //.HasDefaultValue(DateTime.Now)
            //.HasDefaultValueSql("getdate()");


            //kullanicagimiz veri tabanina gore 
            //.HasColumnType("timestamp"); olabilir datetime hepsi desteklemez

            builder.Property(e => e.ModifiedDate)
            .HasColumnType("datetime2")
            .IsRequired(false);
                
        }
    }
}
