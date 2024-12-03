using Application.Dtos.Common;

namespace Application.Dtos.User;

public class UserDetailDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
