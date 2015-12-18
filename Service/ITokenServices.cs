using Entities;

namespace Services
{
    public interface ITokenServices
    {
        bool DeleteByUserId(int userId);
        TokenEntity GenerateToken(int userId);
        bool Kill(string tokenId);
        bool ValidateToken(string tokenId);
    }
}