using System.Security.Cryptography;
using System.Text;

namespace MyCookbook.Aplication.Services.Cryptography;

public class PasswordEncryptor(string chaveAdicional)
{
    private readonly string _additionalKey = chaveAdicional;

    public string Encrypt(string senha)
    {
        var senhaComChaveAdicional = $"{senha}{_additionalKey}";

        var bytes = Encoding.UTF8.GetBytes(senhaComChaveAdicional);
        byte[] hashBytes = SHA512.HashData(bytes);
        return StringBytes(hashBytes);
    }

    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }
        return sb.ToString();
    }
}
