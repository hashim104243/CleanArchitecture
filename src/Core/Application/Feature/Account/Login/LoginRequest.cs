using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.Feature.Account.Login
{
    public class LoginRequest : IRequest<AuthenticationResponse>
    {
        public readonly LoginUserDTO loginUser;

        public LoginRequest(LoginUserDTO loginUser)
        {
            this.loginUser = loginUser;
        }
    }
}
