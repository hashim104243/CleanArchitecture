using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using MediatR;

namespace Application.Feature.Account.Register
{
    public class RegisterRequest : IRequest<bool>
    {
        public readonly RegisterUserDTO registerUser;

        public RegisterRequest(RegisterUserDTO registerUser)
        {
            this.registerUser = registerUser;
        }
    }
}
