using LoQ.DAL.Entities;
using LoQ.DAL.Repositories.Interfaces;
using LoQ.DAL.Repositories.Realizations.Base;

namespace LoQ.DAL.Repositories.Realizations
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(DataContext dbContext)
        : base(dbContext)
        {
        }
    }
}
