using FluentResults;
using LoQ.BLL.DTO;
using MediatR;

namespace LoQ.BLL.MediatR.Questionnaire.GetAll
{
    public record GetAllQuestionnairiesQuery : IRequest<Result<IEnumerable<QuestionnaireDTO>>>;
}
