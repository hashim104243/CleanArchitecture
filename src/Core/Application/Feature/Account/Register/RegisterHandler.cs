using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositores;
using MediatR;

namespace Application.Feature.Account.Register
{
    public class RegisterHandler : IRequestHandler<RegisterRequest, bool>
    {
        private readonly IAccountRepository userRepository;

        public RegisterHandler(IAccountRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var result = await userRepository.RegiterUser(request.registerUser);
            return result;
        }
    }
}
