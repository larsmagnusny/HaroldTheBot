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
        void ReactionRemoved(DiscordClient s, MessageReactionRemoveEventArgs e);
        void ReactionAdded(DiscordClient s, MessageReactionAddEventArgs e);
        void MessageCreated(DiscordClient s, MessageCreateEventArgs e);
    }
}
