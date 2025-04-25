using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Repositores
{
    public interface IAccountRepository
    {
        Task<bool> RegiterUser(RegisterUserDTO registerUser);
        Task<AuthenticationResponse> LoginUser(LoginUserDTO registerUser);
    }
}
