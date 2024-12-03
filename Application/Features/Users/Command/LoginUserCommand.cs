using Application.Common.Interfaces;
using Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Command;

public class LoginUserCommand : ITransactionRequest<UserDto>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
