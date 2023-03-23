using FluentResults;
using LoQ.BLL.DTO;
using MediatR;

namespace LoQ.BLL.MediatR.User.GetByLoginParams
{
    public record GetUsersByLoginParamsQuery(string username, string password) : IRequest<Result<UserDTO>>;
}
