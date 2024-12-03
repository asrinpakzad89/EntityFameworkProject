using Application.Common.Interface;
using Application.Dtos.Common;
using Application.Dtos.Token;
using Application.Dtos.User;
using AutoMapper;
using MediatR;
using Persistence.Repositories;

namespace Application.Features.Users.Command;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private LoginUserCommand _command;
    public LoginUserCommandHandler(IUserRepository userRepository, ITokenService tokenService, IMapper mapper)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _mapper = mapper;
        _command = new();
    }
    public async Task<UserDto> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        _command = command;
        var userDetailDto = await LoginUser(cancellationToken);
        userDetailDto.Role = Role.User;

        var token = CreateToken(userDetailDto);
        return new UserDto
        {
            TokenDto = token,
            UserDetailDto = userDetailDto
        };
    }
    private async Task<UserDetailDto> LoginUser(CancellationToken cancellationToken)
    {
        var userDetailDto = await _userRepository.GetUserByUsernameAndPassword(_command.Username, _command.Password, cancellationToken);
        return _mapper.Map<UserDetailDto>(userDetailDto);
    }
    private TokenDto CreateToken(UserDetailDto userDetailDto)
    {
        return _tokenService.GenerateToken(userDetailDto);
    }
}
