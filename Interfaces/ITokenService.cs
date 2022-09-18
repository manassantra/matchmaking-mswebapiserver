using mswebapiserver.Models;
using mswebapiserver.Models.User;

namespace mswebapiserver.Interfaces
{
    public interface ITokenService
    {
        // Token Creation for Admins
        string CreateToken(AdminUser admin);


        // Token Creation for Agents
        string CreateToken(AgentUser agent);


        // Token Creation for Users
        string CreateToken(AppUser user);
    }
}
