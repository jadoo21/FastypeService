using FastypeService.Data;
using Microsoft.AspNetCore.Mvc;

namespace FastypeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ApplicationDbContext context) : Controller
    {
        // TODO: Add login & signup endpoint
    }
}
