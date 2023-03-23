using AutoMapper;
using LoQ.BLL.DTO;
using LoQ.BLL.MediatR.Questionnaire.Get;
using LoQ.BLL.MediatR.Questionnaire.GetAll;
using LoQ.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace LoQ.Controllers
{
    public class QuestionnaireController : BaseApiController
    {
        private readonly IMediator _mediator;

        public QuestionnaireController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new GetAllQuestionnairiesQuery()));
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetById(int id)
        {
            return HandleResult(await Mediator.Send(new GetQuestionnaireQuery(id)));
        }
    }
}
