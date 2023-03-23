using AutoMapper;
using FluentResults;
using LoQ.BLL.DTO;
using LoQ.BLL.MediatR.Questionnaire.GetAll;
using LoQ.DAL.Repositories.Interfaces.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoQ.BLL.MediatR.User.GetByLoginParams
{
    public class GetUsersByLoginParamsHandler : IRequestHandler<GetUsersByLoginParamsQuery, Result<UserDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GetUsersByLoginParamsHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<Result<UserDTO>> Handle(GetUsersByLoginParamsQuery request, CancellationToken cancellationToken)
        {
            var user = await _repositoryWrapper.UserRepository
                .GetSingleOrDefaultAsync(o => o.Username.ToLower() == request.username.ToLower() &&
                    o.Password.ToLower() == request.password.ToLower());

            if (user is null)
            {
                return Result.Fail(new Error($"Cannot find any user"));
            }

            var categoryDtos = _mapper.Map<UserDTO>(user);
            return Result.Ok(categoryDtos);
        }
    }
}
