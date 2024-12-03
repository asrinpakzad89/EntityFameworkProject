using Application.Dtos.User;
using Application.Features.Users.Command;
using Framework.Api;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace EFProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    //[HttpPost]
    //public async Task<ApiResult<UserDto>> GetUserById(GetUserByIdQuery query)
    //{
    //    return await _mediator.Send(query);
    //}
    [HttpPost]
    public async Task<ApiResult<UserDto>> LoginUser(LoginUserCommand command)
    {
        return await _mediator.Send(command);
    }
}
