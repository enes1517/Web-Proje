using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webgiris2.Models;

namespace webgiris2.repositories.Config
{
    public class deneConfig : IEntityTypeConfiguration<dene>
    {
        public void Configure(EntityTypeBuilder<dene> builder)
        {
            builder.HasData(
                
                new dene { Id = 1, Name = "kemal", age = 10 },
                new dene { Id = 2, Name = "osman", age = 80 },
                new dene { Id = 3, Name = "Ali", age = 50 }





                );
        }
    }
}
