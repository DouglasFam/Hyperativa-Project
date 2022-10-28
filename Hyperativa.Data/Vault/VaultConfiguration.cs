using Hyperativa.Business.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.AppRole;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;
using VaultSharp.V1.SecretsEngines;

namespace Hyperativa.Data.Vault
{
    public class VaultConfigurationProvider : ConfigurationProvider
    {
        public VaultOptions _config;
        private IVaultClient _client;

        public VaultConfigurationProvider(VaultOptions config)
        {
            _config = config;

            IAuthMethodInfo authMethod = new TokenAuthMethodInfo(config.Secret);
            var vaultClientSettings = new VaultClientSettings(config.Address, authMethod); ;

            _client = new VaultClient(vaultClientSettings);
        }

        public override void Load()
        {
            LoadAsync().Wait();
        }

        public async Task LoadAsync()
        {
            await GetDatabaseCredentials();
        }

        public async Task GetDatabaseCredentials()
        {
            try
            {
                var userID = "";
                var password = "";

                if (_config.SecretType == "secret")
                {
                    Secret<SecretData> secrets = await _client.V1.Secrets.KeyValue.V2.ReadSecretAsync(
                        mountPoint: "secret", path: "connection");
                     // path: "secret/connection", version: 2, mountPoint: "secret");
                      //_config.MountPath);

                    userID = secrets.Data.Data["userid"].ToString();
                    password = secrets.Data.Data["password"].ToString();
                }

                if (_config.SecretType == "database")
                {
                    Secret<UsernamePasswordCredentials> dynamicDatabaseCredentials =
                    await _client.V1.Secrets.Database.GetCredentialsAsync(
                      _config.Role,
                      _config.MountPath + _config.SecretType);

                    userID = dynamicDatabaseCredentials.Data.Username;
                    password = dynamicDatabaseCredentials.Data.Password;
                }

                Data.Add("database:userID", userID);
                Data.Add("database:password", password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
