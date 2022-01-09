using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    interface IMessageMonitorer
    {
        Task ReactionRemoved(DiscordClient s, MessageReactionRemoveEventArgs e);
        Task ReactionAdded(DiscordClient s, MessageReactionAddEventArgs e);
        Task MessageCreated(DiscordClient s, MessageCreateEventArgs e);
    }
}
