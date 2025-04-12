using IntraNet.Models;

namespace IntraNet.Services
{
    public interface IAccountService
    {
        Task<string> GenerateJwt(LoginDto dto, CancellationToken cancellationToken);
    }
}
