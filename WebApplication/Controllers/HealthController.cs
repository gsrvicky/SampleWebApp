using Microsoft.AspNetCore.Mvc;
using Itr.Identity.Authentication;
using Itr.Identity.Controllers;

namespace WebApplication.Controllers
{
    [Route("WebApplication/[controller]")]
    [ApiController]
    public class HealthController : ItrHealthController
    {
        public HealthController(IItrTokenManager tokenManager) : base(tokenManager)
        {
        }
    }
}
