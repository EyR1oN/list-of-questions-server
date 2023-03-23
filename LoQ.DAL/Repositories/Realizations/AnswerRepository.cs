using LoQ.DAL.Entities;
using LoQ.DAL.Repositories.Interfaces;
using LoQ.DAL.Repositories.Realizations.Base;

namespace LoQ.DAL.Repositories.Realizations
{
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(DataContext dbContext)
        : base(dbContext)
        {
        }

    }
}
