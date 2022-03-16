using Microsoft.Extensions.Configuration;
using TP04.Classes;

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddUserSecrets<Program>()
    .Build();

new IHM(config.GetConnectionString("Default")).Demarrer();