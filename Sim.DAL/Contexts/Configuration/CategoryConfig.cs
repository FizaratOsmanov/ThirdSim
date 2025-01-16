using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sim.DAL.Models;

namespace Sim.DAL.Contexts.Configuration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
