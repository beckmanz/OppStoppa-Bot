using DSharpPlus;
using DSharpPlus.Commands.Processors.SlashCommands;
using DSharpPlus.Commands.Processors.TextCommands;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Configuration;

namespace OppStoppa
{
    class Program
    {
        public static DiscordClient Client { get; set; }
        public static CommandsNextExtension Commands { get; set; } 

        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            
            string TokenBot = configuration["AppSettings:DiscordToken"];
            string Prefix = configuration["AppSettings:Prefix"];
            
            if(string.IsNullOrWhiteSpace(TokenBot))
            {
                Console.WriteLine("Erro, Token do discord não configurado, configure-o em appsettings.json e tente novamente!");
                Environment.Exit(1);
            }
            DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(TokenBot, DiscordIntents.AllUnprivileged | DiscordIntents.All | TextCommandProcessor.RequiredIntents | SlashCommandProcessor.RequiredIntents);
            
            DiscordClient client = builder.Build();
            await client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}