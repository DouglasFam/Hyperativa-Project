using Hyperativa.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace Hyperativa.App.Configuration
{
    public class ConnectionConfig 
    {
        ConnectionString connectionString;
        private readonly IConfiguration configuration;
        ConfigurationManager configurationManager;

        //public ConnectionConfig(ConnectionString connectionString, IConfiguration configuration)
        //{
        //    this.connectionString = connectionString;
        //    this.configuration = configuration;
        //}
        public ConnectionConfig()
        {

        }
        public async void ApplyVaultConnection()
        {
            //var userid = "";
            //var password = "";
            //HttpClient httpClient = HttpClientFactory.Create();

            //string url = "http://127.0.0.1:8200/v1/secret/data/connection";

            //httpClient.DefaultRequestHeaders.Add("X-Vault-Token", " s.wi2Q59oPVzFYA9packQggudE");

            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //JObject json = JObject.Parse(await httpClient.GetStringAsync(url));

            //Console.WriteLine(json);

            //JToken secrets = json["data"]["data"];

            //Console.WriteLine("\n" + secrets);

            //Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(secrets.ToString());

            //foreach (var item in values)
            //{

            //    Console.WriteLine($"Key: {item.Key} Value: {item.Value}");

            //    if (item.Key == "userid") userid = item.Value;
            //    if (item.Key == password) password = item.Value;
            //    DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
            //    builder.ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Hyperativadb;user id=*****;password=*****;MultipleActiveResultSets=True";
            //    builder["user id"] = userid;
            //    builder["password"] = password;
            //}

            this.connectionString.Connection = configurationManager.GetConnectionString("DefaultConnection").ToString();
            var kvpPath = configurationManager.GetConnectionString("DefaultConnection").ToString();
            configuration.GetConnectionString(this.connectionString.Connection);

            IAuthMethodInfo authMethod = new TokenAuthMethodInfo("s.wi2Q59oPVzFYA9packQggudE");

            // Initialize settings. You can also set proxies, custom delegates etc. here.
            var vaultClientSettings = new VaultClientSettings("https://MY_VAULT_SERVER:8200", authMethod);

            IVaultClient vaultClient = new VaultClient(vaultClientSettings);

            Secret<SecretData> secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync("http://127.0.0.1:8200/v1/secret/data/connection", mountPoint: "kv");
            foreach (var kvp in secret.Data.Data)
            {
                // Console.WriteLine(kvp.Key + " : " + kvp.Value);
            }
        }

        private void GetConnectionString(string userid, string password)
        {
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
            builder.ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Hyperativadb;user id=*****;password=*****;MultipleActiveResultSets=True";
            builder["user id"] = userid;
            builder["password"] = password;

            //this.connectionString.Connection.Replace("ØUSERIDØ", userid);
            //this.connectionString.Connection.Replace("ØPASSWORDØ", password);
        }
    }
}
