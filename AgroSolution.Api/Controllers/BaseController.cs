using AgroSolution.Core.App.Common;
using Microsoft.AspNetCore.Mvc;

namespace AgroSolution.Auth.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IActionResult CustomResponse<T>(Result<T> result)
    {
        if (result.Success)
        {
            return Ok(new
            {
                success = true,
                data = result.Data
            });
        }

        return result.ErrorMessage switch
        {
            "Invalid credentials." => Unauthorized(new { success = false, errors = new[] { result.ErrorMessage } }),
            "User not found." => NotFound(new { success = false, errors = new[] { result.ErrorMessage } }),
            _ => BadRequest(new { success = false, errors = new[] { result.ErrorMessage } })
        };
    }
}