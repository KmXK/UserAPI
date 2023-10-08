namespace UA.Infrastructure.Services.Interfaces;

public interface ICryptoService
{
    string HashText(string plainText);
}