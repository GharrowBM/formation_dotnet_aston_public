using Microsoft.Extensions.Configuration;
using TP03.Classes;

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddUserSecrets<Program>()
    .Build();

new IHM(config.GetConnectionString("Default")).Demarrer();