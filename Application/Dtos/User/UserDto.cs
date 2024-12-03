using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.Token;

namespace Application.Dtos.User;

public class UserDto
{
    public TokenDto TokenDto { get; set; }
    public UserDetailDto UserDetailDto { get; set; }
}
