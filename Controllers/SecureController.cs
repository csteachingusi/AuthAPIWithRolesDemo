using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPIWithRolesDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class SecureController : ControllerBase
    {
        [Authorize(Roles = "Admin")] // Only Admin can access this endpoint
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is a secure endpoint.");
        }
    }
}
