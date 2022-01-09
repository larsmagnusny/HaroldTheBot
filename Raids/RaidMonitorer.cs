using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HaroldTheBot.Raids
{
    public class RaidMonitorer : IRaidMonitorer
    {
        private readonly IRaidService _raidService;
        public RaidMonitorer(IRaidService raidService)
        {
            _raidService = raidService;
        }

        

        public async void Run()
        {
            while (true)
            {
                RaidEvent raidToNotify = null;

                var raids = _raidService.GetRaids();

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

                if (raidToNotify != null)
                {
                    while (DiscordUtils.GetSurgeonRole() == null)
                    {
                        Thread.Sleep(1000);
                    }

                    var surgeon = DiscordUtils.GetSurgeonRole();

                    var channel = await raidToNotify.GetChannel();

                    await channel.SendMessageAsync($"{surgeon.Mention} the raid {raidToNotify.Title} starts in ten minutes. \n{RandomPhrases.GetRandomBattleString()}");
                }

                Thread.Sleep(1000);
            }
        }
    }
}
