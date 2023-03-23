namespace LoQ.DAL.Repositories.Interfaces.Base
{
    public interface IRepositoryWrapper
    {
        IAnswerRepository AnswerRepository { get; }
        IQuestionnaireRepository QuestionnaireRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IUserRepository UserRepository { get; }

        public int SaveChanges();

        public Task<int> SaveChangesAsync();
    }
}
