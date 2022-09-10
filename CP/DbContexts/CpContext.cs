using CP.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP.DbContexts
{
    public class CpContext : DbContext
    {
        public CpContext(DbContextOptions<CpContext> options) :base(options)
        {

        }

       public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }

       public virtual DbSet<ConsultantInfo> ConsultantInfo { get; set; }

       public virtual DbSet<DiscretionaryRules> DiscretionaryRules { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CustomerInfo>(
                entity =>
                {
                    entity.HasKey(e => e.CustomerInfoId);
                    entity.Property(e => e.CustomerInfoId).ValueGeneratedOnAdd();
                    
                });

            modelBuilder.Entity<ConsultantInfo>(
                entity =>
                {
                    entity.HasKey(e => e.ConsultantInfoId);
                    entity.Property(e => e.ConsultantInfoId).ValueGeneratedOnAdd();

                });
            modelBuilder.Entity<DiscretionaryRules>(
                entity =>
                {
                    entity.HasKey(e => e.DiscretionaryRuleId);
                    entity.Property(e => e.DiscretionaryRuleId).ValueGeneratedOnAdd();
                    entity.HasOne(e => e.CustomerInfo).WithMany(p => p.DiscretionaryRules).HasForeignKey(e => e.CustomerInfoId);
                });

            //modelBuilder.Entity<ConsultantInfo>(
            //    entity =>
            //    {
            //        entity.Property(e => e.ConsultantInfoId).HasDefaultValueSql("NEWID()");
            //    });

            base.OnModelCreating(modelBuilder);
        }
    }
}
