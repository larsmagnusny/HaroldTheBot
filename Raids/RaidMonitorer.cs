using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HaroldTheBot.Raids
{
    public static class RaidMonitorer
    {
        public static DiscordRole GetSurgeonRole()
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

        public static async void Run()
        {
            while (true)
            {
                RaidEvent raidToNotify = null;

                lock (RaidStorage.eventLock)
                {
                    var raids = RaidStorage.GetRaids();

                    if (raids != null)
                    {
                        var now = DateTime.UtcNow;
                        var tenMinutesAgo = DateTime.UtcNow.AddMinutes(10);

                        foreach (var raid in raids)
                        {
                            if (raid.Expired)
                                continue;

                            raid.Expired = raid.EventStart < now;

                            if (raid.Expired)
                            {
                                raid.Notified = true;
                                _ = raid.UpdateMessage();
                            }
                            if (!raid.Notified)
                            {
                                raid.Notified = raid.EventStart < tenMinutesAgo;

                                if (raid.Notified)
                                {
                                    raidToNotify = raid;
                                }
                            }
                        }
                    }
                }

                if (raidToNotify != null)
                {
                    while (GetSurgeonRole() == null)
                    {
                        Thread.Sleep(1000);
                    }

                    var surgeon = GetSurgeonRole();

                    var channel = await raidToNotify.GetChannel();

                    await channel.SendMessageAsync($"{surgeon.Mention} the raid {raidToNotify.Title} starts in ten minutes. \n{RandomPhrases.GetRandomBattleString()}");
                }

                Thread.Sleep(1000);
            }
        }
    }
}
