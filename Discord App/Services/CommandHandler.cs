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
            await channel.SendMessageAsync("Gözüm üzerinizde kekeler");

        }
        private Timer timer;
        private Timer longTimer;
        private async void CheckInsuranceDatabase(object sender, ElapsedEventArgs e)
        {
            var insuranceRegService = new InsuranceRegService();
            var entityInsurance = insuranceRegService.CheckData();


            if (entityInsurance != null)
            {
                var user = new UserService().GetByParameter(x => x.Id == entityInsurance.DoctorId);
                var insurance = new InsuranceService().GetByParameter(x => x.Id == entityInsurance.InsuranceId);
                var channel = _discord.GetChannel(929412077116866570) as ITextChannel;
                var embedBuilder = new EmbedBuilder()
                .WithThumbnailUrl("https://w7.pngwing.com/pngs/462/783/png-transparent-star-of-life-emergency-medical-services-emergency-medical-technician-paramedic-star-of-life-angle-text-logo.png")
                .AddField("Hasta Adı", entityInsurance.NameSurname)
                .AddField("Doktor", "<@" + user.DiscordId + ">")
                .AddField("Paket", insurance.PackageName)
                .AddField("Fiyat", insurance.Price)
                .AddField("Bitiş Tarihi", entityInsurance.ExpireDate.ToShortDateString())
                .WithCurrentTimestamp();
                var embed = embedBuilder.Build();
                await channel.SendMessageAsync(null, false, embed);
                await insuranceRegService.UpdateData(entityInsurance);
            }
        }
        private async void CheckExaminationDatabase(object sender, ElapsedEventArgs e)
        {

            var serviceExamination = new ExaminationService();
            var entityExamination = serviceExamination.CheckData();
            if (entityExamination != null)
            {
                var user = new UserService().GetByParameter(x => x.Id == entityExamination.DoctorId);

                if (entityExamination.isJudical)
                {
                    entityExamination.OfficerName =  entityExamination.OfficerName ?? "--";
                    var channel = _discord.GetChannel(929412077116866576) as ITextChannel;
                    var embedBuilder = new EmbedBuilder()
                    .WithThumbnailUrl("https://w7.pngwing.com/pngs/462/783/png-transparent-star-of-life-emergency-medical-services-emergency-medical-technician-paramedic-star-of-life-angle-text-logo.png")
                    .AddField("Hasta Adı", entityExamination.NameSurname)
                    .AddField("Doktor", "<@" + user.DiscordId + ">")
                    .AddField("Müdahale Derecesi", entityExamination.ProcessId)
                    .AddField("Tanı", entityExamination.Diagnosis)
                    .AddField("Fatura", entityExamination.Price)
                    .AddField("Sigortası", entityExamination.HaveInsurance ? "Var" : "Yok")
                    .AddField("İlgilenen Memur", entityExamination.OfficerName)
                    .WithCurrentTimestamp();
                    var embed = embedBuilder.Build();
                    await channel.SendMessageAsync(null, false, embed);
                    await serviceExamination.UpdateData(entityExamination);
                }
                else
                {
                    var channel = _discord.GetChannel(929412077116866575) as ITextChannel;
                    var embedBuilder = new EmbedBuilder()
                    .WithThumbnailUrl("https://w7.pngwing.com/pngs/462/783/png-transparent-star-of-life-emergency-medical-services-emergency-medical-technician-paramedic-star-of-life-angle-text-logo.png")
                    .AddField("Hasta Adı", entityExamination.NameSurname)
                    .AddField("Doktor", "<@" + user.DiscordId + ">")
                    .AddField("Müdahale Derecesi", entityExamination.ProcessId)
                    .AddField("Tanı", entityExamination.Diagnosis)
                    .AddField("Fatura", entityExamination.Price)
                    .AddField("Sigortası", entityExamination.HaveInsurance ? "Var" : "Yok")
                    .WithCurrentTimestamp();
                    var embed = embedBuilder.Build();
                    await channel.SendMessageAsync(null, false, embed);
                    await serviceExamination.UpdateData(entityExamination);
                }

            }


        }
        private async void CheckShiftDatabase(object sender, ElapsedEventArgs e)
        {
            var shiftService = new ShiftService();
            var shiftDatas = shiftService.CheckAllData();
            if (shiftDatas != null)
            {
                foreach (var item in shiftDatas)
                {


                    var endShift = "";

                    if (item.EndDate == null)
                    {
                        endShift = "--";
                    }
                    else
                    {
                        endShift = item.EndDate.ToString();
                    }
                    var userService = new UserService();
                    var user = userService.GetByParameter(x => x.Id == item.UserId);

                    var channel = _discord.GetChannel(929412077116866574) as ITextChannel;
                    var embedBuilder = new EmbedBuilder()
                    .WithThumbnailUrl("https://w7.pngwing.com/pngs/462/783/png-transparent-star-of-life-emergency-medical-services-emergency-medical-technician-paramedic-star-of-life-angle-text-logo.png")
                    .AddField("Doktor Adı", user.NameSurname)
                    .AddField("Doktor", "<@" + user.DiscordId + ">")
                    .AddField("Giriş Saati", item.StartDate)
                    .AddField("Çıkış Saati", endShift)
                    .WithCurrentTimestamp();
                    var embed = embedBuilder.Build();
                    await channel.SendMessageAsync(null, false, embed);
                    await shiftService.UpdateData(item);
                }
            }


        }
        private async void CheckPaidDatabase(object sender, ElapsedEventArgs e)
        {
            var paidSalariesService = new PaidSalaryService();
            var paidSalaries = paidSalariesService.CheckData();
            var paidSalariesToManagement = paidSalariesService.CheckAllData();

            if (paidSalariesToManagement != null)
            {
                var userService = new UserService();
                var doctorList = userService.GetAllByParameter(x => x.JobId == 2);
                var examinationService = new ExaminationService();
                var insuranceRegService = new InsuranceRegService();
                var payChecksManager = new PayChecksService();

                var channelDiscord = _discord.GetChannel(947405728082169886) as ITextChannel;
                foreach (var doctor in doctorList)
                {
                    var doctorsPaycheck = payChecksManager.GetByParameter(x => x.UserId == doctor.Id && x.IsPaid == false);
                    var lastPaid = paidSalariesService.GetLastPaid(doctor.Id);
                    var examinationCount = lastPaid != null ? examinationService.GetAllByParameter(x => x.DoctorId == doctor.Id && x.CreateTime > lastPaid.CreateTime).Count() : examinationService.GetAllByParameter(x => x.DoctorId == doctor.Id).Count();
                    var insuranceCount = lastPaid != null ? insuranceRegService.GetAllByParameter(x => x.DoctorId == doctor.Id && x.CreateTime > lastPaid.CreateTime).Count() : insuranceRegService.GetAllByParameter(x => x.DoctorId == doctor.Id).Count();
                    if (doctorsPaycheck == null)
                        continue;

                    var embedBuilder = new EmbedBuilder()
                   .WithThumbnailUrl("https://w7.pngwing.com/pngs/462/783/png-transparent-star-of-life-emergency-medical-services-emergency-medical-technician-paramedic-star-of-life-angle-text-logo.png")
                   .AddField("Doktor Adı", doctor.NameSurname)
                   .AddField("Kart Türü", "Ek Prim Kartı")
                   .AddField("Hasta Kaydı", examinationCount)
                   .AddField("Yaptığı Sigorta", insuranceCount)
                   .AddField("Aldığı Para", doctorsPaycheck.CurrentPay)
                   .WithCurrentTimestamp();
                    var embed = embedBuilder.Build();

                    if (paidSalaries != null)
                    {
                        IUser userDiscord = _discord.GetUser((ulong)doctor.DiscordId); // Get the User (wait atleast 10sec after starting)
                        if (userDiscord == null)
                            continue;
                        var channel = await userDiscord.GetOrCreateDMChannelAsync(); // Get/Create a DM Channel
                        var embedBuilderDM = new EmbedBuilder()
                        .WithThumbnailUrl("https://w7.pngwing.com/pngs/462/783/png-transparent-star-of-life-emergency-medical-services-emergency-medical-technician-paramedic-star-of-life-angle-text-logo.png")
                        .AddField("Doktor Adı", doctor.NameSurname)
                        .AddField("Kart Türü", "Ek Prim Kartı")
                        .AddField("Mesaj", "Verdiğiniz Emekler için teşekkür ederiz <3")
                        .AddField("Ek Ödeme", paidSalaries.Salary)
                        .WithCurrentTimestamp();
                        var embedDM = embedBuilderDM.Build();
                        await userDiscord.SendMessageAsync(null, false, embedDM);
                        await channelDiscord.SendMessageAsync(null, false, embed);
                        await paidSalariesService.UpdateData(paidSalaries);
                    }

                }
            }
        }
        private async Task OnUserLeft(SocketGuildUser user)
        {
            var channel = await user.GetOrCreateDMChannelAsync();
            await channel.SendMessageAsync($"Ayb dii mi lan");
        }

        private Task OnReady()
        {
            Console.WriteLine($"Connected as {_discord.CurrentUser.Username}#{_discord.CurrentUser.Discriminator}");

            timer = new Timer(1000 * 45);
            longTimer = new Timer(1000 * 45);
            longTimer.Elapsed += new ElapsedEventHandler(CheckPaidDatabase);
            timer.Elapsed += new ElapsedEventHandler(CheckExaminationDatabase);
            timer.Elapsed += new ElapsedEventHandler(CheckInsuranceDatabase);
            timer.Elapsed += new ElapsedEventHandler(CheckShiftDatabase);
            timer.Start();
            longTimer.Start();
            return Task.CompletedTask;


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

