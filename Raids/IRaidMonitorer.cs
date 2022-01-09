using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Raids
{
    public interface IRaidMonitorer
    {
        DiscordRole GetSurgeonRole()
        {
            DiscordRole surgeon = null;

            if (Program.DiscordClient == null)
                return null;
            if (Program.DiscordClient.Guilds == null)
                return null;

            foreach (var guild in Program.DiscordClient.Guilds)
            {
                foreach (var role in guild.Value.Roles)
                {
                    if (role.Value.Name == "Surgeon")
                        surgeon = role.Value;
                }
            }

            return surgeon;
        }

        public void Run();
    }
}
