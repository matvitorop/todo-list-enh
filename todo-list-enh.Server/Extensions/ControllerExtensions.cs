using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace todo_list_enh.Server.Extensions
{
    public static class ControllerExtensions
    {
        public static int GetUserIdOrThrowUnauthorized(this ControllerBase controller)
        {
            var userIdStr = controller.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId))
            {
                throw new UnauthorizedAccessException("User ID is missing in the token.");
            }
            return userId;
        }
    }
}
