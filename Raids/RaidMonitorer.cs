using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public RaidMonitorer(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async void Run()
        {
            while (true)
            {
                RaidEvent raidToNotify = null;

                try
                {
                    using var scope = _serviceScopeFactory.CreateScope();

                    var raidService = (IRaidService)scope.ServiceProvider.GetService(typeof(IRaidService));

                    var raids = raidService.GetRaids().OrderByDescending(o => o.EventStart).ToList();

                    if (raids != null)
                    {
                        var now = DateTime.UtcNow;
                        var tenMinutesAgo = DateTime.UtcNow.AddMinutes(10);

                        foreach (var raid in raids)
                        {
                            if (raid.Expired && !raid.Notified)
                            {
                                raid.Notified = true;
                                await raid.UpdateMessage(raidService);
                                raidService.SetRaidNotified(raid.Id);
                                break;
                            }

                            if (!raid.Notified)
                            {
                                raid.Notified = raid.EventStart < tenMinutesAgo;

                                if (raid.Notified)
                                {
                                    raidToNotify = raid;
                                    break;
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

                        raidService.SetRaidNotified(raidToNotify.Id);
                    }
                } 
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }

                Thread.Sleep(2000);
            }
        }
    }
}
