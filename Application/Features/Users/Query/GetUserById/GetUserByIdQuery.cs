using Application.Common.Interfaces;
using Application.Dtos.User;

namespace Application.Features.Users.Query.GetUserById;

public class GetUserByIdQuery : ITransactionRequest<UserDto>
{
    public int Id { get; set; }
}
