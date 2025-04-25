using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Repositores;
using MediatR;

namespace Application.Feature.Account.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, AuthenticationResponse>
    {
        private readonly IAccountRepository accountRepository;

        public LoginHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task<AuthenticationResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = await accountRepository.LoginUser(request.loginUser);
            return result;
        }
    }
}
