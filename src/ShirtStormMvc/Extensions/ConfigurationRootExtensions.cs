using ShirtStormCommon.Cipher;

namespace ShirtStormMvc.Extensions
{
    public static class ConfigurationRootExtensions
    {
        public static IConfigurationRoot Decrypt(this IConfigurationRoot configurationRoot, string secret)
        {
            var byteSecret = Convert.FromBase64String(secret);
            DecryptInChildren(configurationRoot, byteSecret);
            return configurationRoot;

            void DecryptInChildren(IConfiguration parent, byte[] secret)
            {
                var cipherPrefix = "CipherText:";
                foreach (var child in parent.GetChildren())
                {
                    if (child.Value?.StartsWith(cipherPrefix) == true)
                    {
                        var cipherText = child.Value.Substring(cipherPrefix.Length);
                        parent[child.Key] = Aes256Cipher.Decrypt(cipherText, secret);
                    }

                    DecryptInChildren(child, secret);
                }
            }
        }
    }
}
