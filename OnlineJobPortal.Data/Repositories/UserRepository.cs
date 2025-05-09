using OnlineJobPortal.Data.Contexts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Data.Repositories;

public class UserRepository(OnlineJobPortalDbContext context) : BaseRepository<User>(context)
{
    public override Task AddAsync(User entity)
    {
        entity.RoleId = 1;
        entity.StatusId = 1;
        return base.AddAsync(entity);
    }
}
