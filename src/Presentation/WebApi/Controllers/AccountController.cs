using Application.DTO;
using Application.Feature.Account;
using Application.Feature.Account.Login;
using Application.Feature.Account.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("LoginUser")]
        public async Task<AuthenticationResponse> Login([FromBody] LoginUserDTO loginUser)
        {
            var loginu =await mediator.Send(new LoginRequest(loginUser));
            return loginu;
        }

        [HttpPost("RegisterUser")]
        public async Task<bool> Register([FromBody]  RegisterUserDTO registerUser)
        {
            if (registerUser == null)
            {
            throw new NotImplementedException("valules are null");
                
            }
            

                var result =await mediator.Send(new RegisterRequest(registerUser));
            if (result)
            {
                
            return true;
            }
            return false;
            
            
        }

    }
}
