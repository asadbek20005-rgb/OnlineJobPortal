using OnlineJobPortal.Data.Contexts;
using OnlineJobPortal.Data.Entities;

namespace OnlineJobPortal.Data.Repositories;

public class UserRepository(OnlineJobPortalDbContext context) : BaseRepository<User>(context)
{
    public override Task AddAsync(User entity)
    {
        
        return base.AddAsync(entity);
    }
}
