using Core.Services;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Discord_App.Services
{
    public class CommandHandler
    {
        public static IServiceProvider _provider;
        private static DiscordSocketClient _discord;
        private static CommandService _commands;
        private static IConfigurationRoot _config;

        public CommandHandler(DiscordSocketClient discord, CommandService commands, IConfigurationRoot config, IServiceProvider provider)
        {
            _provider = provider;
            _config = config;
            _discord = discord;
            _commands = commands;

            _discord.Ready += OnReady;
            _discord.MessageReceived += OnMessageReceived;
            _discord.ChannelCreated += OnChannelCreated;
            _discord.UserLeft += OnUserLeft;
        }

        private async Task OnChannelCreated(SocketChannel arg)
        {
            if ((arg as ITextChannel) == null) return;
            var channel = arg as ITextChannel;
            await channel.SendMessageAsync("Channel created");

        }
        private System.Timers.Timer timer;
        private async void CheckDatabase(object sender, ElapsedEventArgs e)
        {
            var channel = _discord.GetChannel(902728499268313129) as ITextChannel;
            //check database any fixes..
            var serviceExamination = new ExaminationService();
            var entityExamination = serviceExamination.CheckData();
            if (entityExamination != null)
            {
                var embedBuilder = new EmbedBuilder()
                    .WithThumbnailUrl("https://w7.pngwing.com/pngs/462/783/png-transparent-star-of-life-emergency-medical-services-emergency-medical-technician-paramedic-star-of-life-angle-text-logo.png")
                    .AddField("Hasta Adı", entityExamination.NameSurname)
                    //.AddField("Doktor", entityExamination.DoctorName)
                    //.AddField("Yapılan Müdahale", entityExamination.Process)
                    //.AddField("Fatura", entityExamination.Bill)
                    .AddField("Sigortası", entityExamination.HaveInsurance ? "Var" : "Yok")
                    .WithCurrentTimestamp();
                var embed = embedBuilder.Build();
                await channel.SendMessageAsync(null, false, embed);
                await serviceExamination.UpdateData(entityExamination);
            }


        }
        private async Task OnUserLeft(SocketGuildUser user)
        {
            var channel = await user.GetOrCreateDMChannelAsync(); // Gets the channel to send the message in
            await channel.SendMessageAsync($"Ayb dii mi lan"); //Welcomes the new user
        }
    
        private Task OnReady()
        {
            Console.WriteLine($"Connected as {_discord.CurrentUser.Username}#{_discord.CurrentUser.Discriminator}");

            timer = new System.Timers.Timer(1000*5); // Timer for 10 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(CheckDatabase);
            timer.Start();
            return Task.CompletedTask;
            
            
        }
        private async Task CheckEmsData()
        {
            IUser user = _discord.GetUser(469155848552185877); // Get the User (wait atleast 10sec after starting)
            var channel = await user.GetOrCreateDMChannelAsync(); // Get/Create a DM Channel
            await channel.SendMessageAsync("sa");
            Console.WriteLine("Tolgaya gönderildi");
        }
        private async Task OnMessageReceived(SocketMessage arg)
        {
            var msg = arg as SocketUserMessage;
            if (msg.Author.IsBot)
                return;
            var context = new SocketCommandContext(_discord, msg);
            int pos = 0;
            if (msg.HasStringPrefix(_config["prefix"], ref pos) || msg.HasMentionPrefix(_discord.CurrentUser, ref pos))
            {
                var result = await _commands.ExecuteAsync(context, pos, _provider);
                if (!result.IsSuccess)
                {
                    var reason = result.Error;

                    await context.Channel.SendMessageAsync("Böyle bi komut yok topraaam");
                    Console.WriteLine(reason);
                }
            }

        }
    }
}

