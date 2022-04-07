using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace DemoUsingAzureVault.Service;

public class SecretService
{
    private SecretClient _secretClient;

    public SecretService()
    {
        _secretClient = new SecretClient(new Uri("https://utopios-p.vault.azure.net/"), new DefaultAzureCredential());
    }

    public string GetTokenSecret(string secretName)
    {
        return _secretClient.GetSecret(secretName).Value.ToString();
    }

    public void SetTokenSecret(string secretName, string secretValue)
    {
        _secretClient.SetSecret(new KeyVaultSecret(secretName, secretValue));
    }
}