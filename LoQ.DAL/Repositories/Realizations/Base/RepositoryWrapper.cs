using LoQ.DAL.Entities;
using LoQ.DAL.Repositories.Interfaces;
using LoQ.DAL.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoQ.DAL.Repositories.Realizations.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _dataContext;

        private IAnswerRepository _answerRepository;

        private IQuestionnaireRepository _questionnaireRepository;

        private IQuestionRepository _questionRepository;

        private IUserRepository _userRepository;

        public IAnswerRepository AnswerRepository
        {
            get
            {
                if (_answerRepository is null)
                {
                    _answerRepository = new AnswerRepository(_dataContext);
                }
                return _answerRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository is null)
                {
                    _userRepository = new UserRepository(_dataContext);
                }
                return _userRepository;
            }
        }

        public IQuestionnaireRepository QuestionnaireRepository
        {
            get
            {
                if (_questionnaireRepository is null)
                {
                    _questionnaireRepository = new QuestionnaireRepository(_dataContext);
                }
                return _questionnaireRepository;
            }
        }

        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository is null)
                {
                    _questionRepository = new QuestionRepository(_dataContext);
                }
                return _questionRepository;
            }
        }

        public RepositoryWrapper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}
