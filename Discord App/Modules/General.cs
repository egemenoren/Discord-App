﻿using Discord.Commands;
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
        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("Pong!");
        }
        [Command("31")]
        public async Task Osbir()
        {
            await Context.Channel.SendMessageAsync("Sj");
        }
    }
}
