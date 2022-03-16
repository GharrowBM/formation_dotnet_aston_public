using Microsoft.Extensions.Configuration;
using TP02.Classes;

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddUserSecrets<Program>()
    .Build();

new IHM(config.GetConnectionString("Default")).Demarrer();