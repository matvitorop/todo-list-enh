using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace todo_list_enh.Server.Extensions
{
    public static class ControllerExtensions
    {
        public static int? GetUserIdOrNull(this ControllerBase controller)
        {
            var userIdStr = controller.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(userIdStr, out var userId) ? userId : null;
        }
    }
}
