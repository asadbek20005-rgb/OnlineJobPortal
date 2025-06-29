using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Data.EntityConfigs;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.PhoneNumber)
            .IsUnique();

    }
}