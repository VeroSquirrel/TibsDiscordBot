using Serilog;
using Serilog.Core;

namespace TibsDiscordBot
{
    internal class Program
    {
        public static Task Main(string[] args) => new Program().MainAsync();
        private readonly Logger logger;

        internal Program()
        {
            logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        public async Task MainAsync()
        {

        }
    }
}