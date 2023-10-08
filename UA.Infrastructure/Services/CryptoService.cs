using System.Security.Cryptography;
using System.Text;
using UA.Infrastructure.Services.Interfaces;

namespace UA.Infrastructure.Services;

public sealed class CryptoService : ICryptoService
{
    public string HashText(string plainText)
    {
        var bytes = SHA512.HashData(Encoding.UTF8.GetBytes(plainText));
        
        return Convert.ToHexString(bytes);
    }
}