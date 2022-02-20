using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Discord_App.Modules
{
    public class General : ModuleBase
    {
        [Command("salih")]
        public async Task Salih()
        {
            await Context.Channel.SendMessageAsync("Legacy V tarihinin gelmiş geçmiş en iyi başhekimi ve plastik cerrahıdır. Aynı zamanda " +
                "eskiden kendisi HSU birim şefiydi. Ambulansla deli yanlar, doktorlarına çok " +
                "sahip çıkardı. Pamuk sokma işlerine çok yatkındı, bir gün trafik kazasından sonra felç kaldı. O7");


        }
        [Command("31")]
        public async Task Osbir()
        {
            await Context.Channel.SendMessageAsync("sj");
        }
    }
}
