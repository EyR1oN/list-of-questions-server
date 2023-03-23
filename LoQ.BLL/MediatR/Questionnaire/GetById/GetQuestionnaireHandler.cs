using AutoMapper;
using FluentResults;
using LoQ.BLL.DTO;
using LoQ.DAL.Repositories.Interfaces.Base;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LoQ.BLL.MediatR.Questionnaire.Get
{
    public class GetQestionnaireHandler : IRequestHandler<GetQuestionnaireQuery, Result<QuestionnaireDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GetQestionnaireHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<Result<QuestionnaireDTO>> Handle(GetQuestionnaireQuery request, CancellationToken cancellationToken)
        {
            var questionnaire = await _repositoryWrapper
                .QuestionnaireRepository
                .GetFirstOrDefaultAsync(c => c.Id == request.Id, 
                    include: q => q.Include(s => s.Questions).ThenInclude(q => q.Answers));

            if (questionnaire is null)
            {
                return Result.Fail(new Error($"Cannot find any questionnaire"));
            }

            var rand = new Random();

            var questions = questionnaire.Questions.OrderBy(x => rand.Next()).Take(3).ToList();
            questionnaire.Questions = questions;

            var questionnaireDto = _mapper.Map<QuestionnaireDTO>(questionnaire);
            return Result.Ok(questionnaireDto);
        }
    }
}
