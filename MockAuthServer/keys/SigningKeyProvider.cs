using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace MockNexusAuthServer.keys
{
    public class SigningKeyProvider
    {
        public static RsaSecurityKey GetSigningKey()
        {
            string privateKeyXml = ReadPrivateKey();

            var rsaImported = new RSACryptoServiceProvider(2048);
            rsaImported.FromXmlString(privateKeyXml);
            RSAParameters importedPrivateKey = rsaImported.ExportParameters(true);
            var rsaSecurityForSigning = new RsaSecurityKey(importedPrivateKey);
            return rsaSecurityForSigning;
        }

        static string ReadPrivateKey()
        {
            var key = File.ReadAllText(Path.Combine("keys", "signing-key.xml"));
            return key;
        }
    }
}
