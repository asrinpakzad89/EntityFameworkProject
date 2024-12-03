using Application.Common.Interface;
using Application.Dtos.Token;
using Application.Dtos.User;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Identity.Client;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Query.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IEFRepositories<User> _eFRepositories;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private GetUserByIdQuery _query;

    public GetUserByIdQueryHandler(IEFRepositories<User> eFRepositories, IMapper mapper, ITokenService tokenService)
    {
        _eFRepositories = eFRepositories;
        _mapper = mapper;
        _tokenService = tokenService;
        _query = new();
    }
    public async Task<UserDto> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        try
        {
            _query = query;
            var user = await _eFRepositories.GetAsync(_query.Id, cancellationToken);

            TokenDto? token = null;
            token = CreateToken(user);

            return new UserDto
            {
                TokenDto = token,
                UserDetailDto = _mapper.Map<UserDetailDto>(user)
            };
        }
        catch (Exception ex)
        {
            var msg = "کاربری با این شناسه وجود ندارد.";
            throw new KeyNotFoundException(string.Format(msg, ex.Message));
        }

    }
    public TokenDto CreateToken(User user)
    {
        return _tokenService.GenerateToken(new UserDetailDto
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password
        });
    }
}
