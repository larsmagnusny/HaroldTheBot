using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;
using HaroldTheBot;
using System.Reflection;
using System.Globalization;

internal class Program
{
    /* This is the cancellation token we'll use to end the bot if needed(used for most async stuff). */
    private CancellationTokenSource Cts { get; set; }

    /* We'll load the app config into this when we create it a little later. */
    private IConfigurationRoot _config;

    public static CultureInfo CurrentCulture = CultureInfo.GetCultureInfo("nb-NO");

    /* These are the discord library's main classes */
    public static DiscordClient DiscordClient;
    private CommandsNextExtension _commands;

    /* Use the async main to create an instance of the class and await it(async main is only available in C# 7.1 onwards). */
    static async Task Main(string[] args) => await new Program().InitBot(args);

    async Task InitBot(string[] args)
    {
        try
        {
            Console.WriteLine("[info] Harold is waking up!");
            Cts = new CancellationTokenSource();

            Console.Write("[info] Loading save data...");
            RaidStorage.LoadStorage();
            Console.Write($"[info] Loaded data.");

            Thread t = new(StorageThread.Run);
            t.Start();

            Thread t1 = new(RaidMonitorer.Run);
            t1.Start();

            // Load the config file(we'll create this shortly)
            Console.WriteLine("[info] Loading config file..");
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();

            // Create the DSharpPlus client
            Console.WriteLine("[info] Creating discord client..");
            DiscordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = _config.GetValue<string>("discord:token"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.GuildPresences | DiscordIntents.GuildMembers,
                AlwaysCacheMembers = true,
            });

            DiscordClient.MessageReactionAdded += async (s, e) => MessageMonitorer.ReactionAdded(s, e);
            DiscordClient.MessageReactionRemoved += async (s, e) => MessageMonitorer.ReactionRemoved(s, e);
            DiscordClient.MessageCreated += async (s, e) => MessageMonitorer.MessageCreated(s, e);

            // Build dependancies and then create the commands module.
            _commands = DiscordClient.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefixes = new[] { _config.GetValue<string>("discord:CommandPrefix") }, // Load the command prefix(what comes before the command, eg "!" or "/") from our config file
            });

            Console.WriteLine("[info] Loading command modules..");

            _commands.RegisterCommands(Assembly.GetExecutingAssembly());

            RunAsync(args).Wait();
        }
        catch (Exception ex)
        {
            // This will catch any exceptions that occur during the operation/setup of your bot.

            // Feel free to replace this with what ever logging solution you'd like to use.
            // I may do a guide later on the basic logger I implemented in my most recent bot.
            Console.Error.WriteLine(ex.ToString());
        }
    }

    async Task RunAsync(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }
        // Connect to discord's service
        Console.WriteLine("Connecting..");
        await DiscordClient.ConnectAsync();
        Console.WriteLine("Connected!");

        // Keep the bot running until the cancellation token requests we stop
        while (!Cts.IsCancellationRequested)
            await Task.Delay(TimeSpan.FromMinutes(1));
    }
}