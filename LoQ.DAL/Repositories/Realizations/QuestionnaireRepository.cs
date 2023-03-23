using LoQ.DAL.Entities;
using LoQ.DAL.Repositories.Interfaces;
using LoQ.DAL.Repositories.Realizations.Base;

namespace LoQ.DAL.Repositories.Realizations
{
    public class QuestionnaireRepository : RepositoryBase<Questionnaire>, IQuestionnaireRepository
    {
        public QuestionnaireRepository(DataContext dbContext)
        : base(dbContext)
        {
        }
    }
}
