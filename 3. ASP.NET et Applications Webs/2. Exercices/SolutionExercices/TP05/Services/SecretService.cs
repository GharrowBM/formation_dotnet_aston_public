using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace TP05.Services;

public class SecretService
{
    private SecretClient _secretClient;

    public SecretService()
    {
        _secretClient = new SecretClient(new Uri("https://api-pizza.vault.azure.net/"), new DefaultAzureCredential());
    }

    public string GetTokenSecret(string secretName)
    {
        var secret = _secretClient.GetSecret(secretName);
        return secret.Value.Value;
    }

    public void SetTokenSecret(string secretName, string secretValue)
    {
        _secretClient.SetSecret(new KeyVaultSecret(secretName, secretValue));
    }
}