using Application.Dtos.Token;
using Application.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface;

public interface ITokenService
{
    TokenDto GenerateToken(UserDetailDto user);
}
