using System.Security.Claims;
using Application.Interface;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security;
public class UserAccessor : IUserAccessor
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public string GetUser() => httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
}