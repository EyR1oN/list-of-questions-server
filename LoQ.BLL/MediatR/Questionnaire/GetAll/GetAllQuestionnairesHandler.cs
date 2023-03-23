using AutoMapper;
using FluentResults;
using LoQ.BLL.DTO;
using LoQ.DAL.Repositories.Interfaces.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoQ.BLL.MediatR.Questionnaire.GetAll
{
    public class GetAllQestionnairesHandler : IRequestHandler<GetAllQuestionnairiesQuery, Result<IEnumerable<QuestionnaireDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GetAllQestionnairesHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<QuestionnaireDTO>>> Handle(GetAllQuestionnairiesQuery request, CancellationToken cancellationToken)
        {
            var questionnaires = await _repositoryWrapper
                .QuestionnaireRepository
                .GetAllAsync();

            if (questionnaires is null)
            {
                return Result.Fail(new Error($"Cannot find any questionnaires"));
            }

            var questionnairesDtos = _mapper.Map<IEnumerable<QuestionnaireDTO>>(questionnaires);
            return Result.Ok(questionnairesDtos);
        }
    }
}
