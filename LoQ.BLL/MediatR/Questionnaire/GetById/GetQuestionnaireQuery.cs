using FluentResults;
using LoQ.BLL.DTO;
using MediatR;

namespace LoQ.BLL.MediatR.Questionnaire.Get
{
    public record GetQuestionnaireQuery(int Id) : IRequest<Result<QuestionnaireDTO>>;
}
