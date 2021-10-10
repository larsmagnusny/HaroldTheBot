﻿using DSharpPlus.CommandsNext;
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
        private readonly string VoteHelpText =
            @"
""/vote"" takes these parameters
new               - Create a new vote event
remove [id] - Remove a vote event
Example: vote new -t ""VoteName"" -o ""Option1"", ""Option2"", ""Etc...""
Example: vote remove [id]";

        [Command("vote")]
        [Description("@participants to get ready to raid")]
        public async Task Vote(CommandContext ctx, params string[] args)
        {
            await ctx.TriggerTypingAsync();

            if(args == null)
            {
                await ctx.RespondAsync(VoteHelpText);
            }
            if(args.Length == 0)
            {
                await ctx.RespondAsync(VoteHelpText);
            }

            if(args[0] == "new")
            {
                int tIndex = Utils.IndexOf(args, "-t");
                int oIndex = Utils.IndexOf(args, "-o");

                if (!Utils.HasNextParameter(args, tIndex))
                    await ctx.RespondAsync("I expected to get a title, but you gave me nothing... I will be reporting this to my supervisor.");
                if (!Utils.HasNextParameter(args, oIndex))
                    await ctx.RespondAsync("I expected to have some options, but you gave me nothing. How will i ever recover from this travestly.");
            }
            else if(args[0] == "remove")
            {

            }
        }
    }
}
