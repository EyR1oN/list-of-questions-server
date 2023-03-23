using LoQ.DAL.Entities;
using LoQ.DAL.Repositories.Interfaces;
using LoQ.DAL.Repositories.Realizations.Base;

namespace LoQ.DAL.Repositories.Realizations
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext)
        : base(dbContext)
        {
        }
    }
}
