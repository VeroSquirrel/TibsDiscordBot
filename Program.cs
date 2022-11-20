using Discord.WebSocket;
using Serilog;
using Serilog.Core;

namespace TibsDiscordBot
{
    internal class Program
    {
        public static Task Main(string[] args) => new Program().MainAsync();
        private readonly Logger logger;
        private readonly DiscordSocketClient client;
        private readonly string token;

        internal Program()
        {
            logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/tibs_bot_logs.txt", rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            client = new DiscordSocketClient();
            client.Log += Client_Log;

            try
            {
                token = File.ReadAllText("token.txt");
                if (string.IsNullOrWhiteSpace(token)) { throw new Exception(); }
            }
            catch (Exception ex)
            {
                logger.Error("Token cannot be found! Fatal error, exitting...");
            }
        }

        public async Task MainAsync()
        {
            
        }

        private Task Client_Log(Discord.LogMessage msg)
        {
            logger.Information(msg.Message);
            return Task.CompletedTask;
        }
    }
}