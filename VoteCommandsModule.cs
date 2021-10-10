using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public class VoteCommandsModule : BaseCommandModule
    {
        private readonly string VoteHelpText = @"";

        [Command("vote")]
        [Description("@participants to get ready to raid")]
        public async Task Vote(CommandContext ctx, params string[] args)
        {
            await ctx.TriggerTypingAsync();

            if(args == null)
            {
                await ctx.RespondAsync(VoteHelpText);
            }

            if(args[0] == "new")
            {

            }
        }
    }
}
