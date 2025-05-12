using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LoginJWT.Models;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace LoginJWT.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly LoginDbContext _loginDbContext;

        public ProductController(LoginDbContext loginDbContext)
        {
            _loginDbContext = loginDbContext;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var list = await _loginDbContext.Products.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new {value = list});
        }
    }
}
