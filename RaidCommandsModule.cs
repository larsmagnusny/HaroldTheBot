using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
	public class RaidCommandsModule : BaseCommandModule
	{
		private readonly string help =
@"
""/raid"" takes these parameters
new               - Create a new raid event
remove [id] - Remove a raid event
-t                    - Title of the raid event
-dt                  - Start Date and time in UTC (dd/MM/yyyy HH:mm:ss)
-tank                - Number of tank slots
-dps				 - Number of DPS slots
-heal                - Number of healer slots
-r                    - Recurring
Example: raid new -t ""RaidName"" -dt " + DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss")+@" -r
Example: raid remove " + Guid.NewGuid();

		[Command("raid")]
		[Description("@participants to get ready to raid")]
		public async Task Raid(CommandContext ctx, params string[] args)
		{
			/* Trigger the Typing... in discord */
			await ctx.TriggerTypingAsync();

			if (args.Length == 0)
			{
				await ctx.RespondAsync(help);
				return;
			}

			int newIndex = Utils.IndexOf(args, "new");
			int removeIndex = Utils.IndexOf(args, "remove");
            if (newIndex != -1)
            {
				int tIndex = Utils.IndexOf(args, "-t");
				int dtIndex = Utils.IndexOf(args, "-dt");
				//int rIndex = Utils.IndexOf(args, "-r");

				if (tIndex == -1)
				{
					await ctx.RespondAsync("Bro, i need you to define a title or something. Use the -t parameter for gods sake.");
					return;
                }
				if(dtIndex == -1)
                {
					await ctx.RespondAsync("I can't really create a raid if you haven't defined when it starts. Use the -dt parameter please.");
					return;
                }
				if (!Utils.HasNextParameter(args, tIndex))
				{
					await ctx.RespondAsync("I expected to get a title, but you gave me nothing... I will be reporting this to my supervisor.");
					return;
				}
				if(!Utils.HasNextParameter(args, dtIndex))
                {
					await ctx.RespondAsync("I expected to get a date, but you gave me nothing... Should i bring flowers next time?");
					return;
                }
				if(!Utils.HasNextParameter(args, dtIndex + 1))
                {
					await ctx.RespondAsync("I expected to get time as well, I'm a bit busy, is 00:00 OK?");
                }

                int titleIndex = ctx.RawArgumentString.IndexOf("-t \"");
				int titleEndIndex = ctx.RawArgumentString.IndexOf("\"", titleIndex + 4);

				if(titleEndIndex == -1)
                {
					await ctx.RespondAsync("Hmm... The title is missing a '\"'. I need that.");
					return;
                }

                string title = ctx.RawArgumentString.Substring(titleIndex + 3, titleEndIndex - titleIndex - 2);
                string dateTime = args[dtIndex + 1];

                if (dtIndex + 2 <= args.Length - 1)
					dateTime = string.Concat(dateTime, " ", args[dtIndex + 2]);

                //bool recurring = !(rIndex == -1);
                DateTime starttime;
                try
				{
					starttime = DateTime.Parse(dateTime);
				}
                catch
                {
					await ctx.RespondAsync($"\"{dateTime}\" is not a date... You can't fool me.");
					return;
                }
				/* Send the message "I'm Alive!" to the channel the message was recieved from */
				var ev = RaidStorage.AddRaid(title.Trim('"'), starttime);
				var Msg = await ctx.RespondAsync(ev.CreateMessage());
				ev.Message = Msg;
				ev.MessageId = ev.MessageId;
				ev.Channel = Msg.Channel;
				ev.ChannelId = Msg.ChannelId;
				return;
			}
			else if (removeIndex != -1)
            {
				if (!Utils.HasNextParameter(args, removeIndex))
                {
					await ctx.RespondAsync("Remove what? Do you expect me to remove nothing? Ok then.");
					return;
                }

				try
				{
					Guid guid = Guid.Parse(args[removeIndex + 1]);
					var raid = RaidStorage.GetRaid(guid);
					var removed = RaidStorage.RemoveRaid(Guid.Parse(args[removeIndex + 1]));

                    if (!removed || raid == null)
                    {
						await ctx.RespondAsync($"I did not find a raid with the id: {args[removeIndex + 1]}");
						return;
                    }

					await ctx.RespondAsync($"Removed the raid \"{raid.Title}\"");
					return;
				}
				catch {
					await ctx.RespondAsync($"I'm fairly certain that \"{args[removeIndex + 1]}\" is not a valid raid-id");
					return;
				}
			}

			/* Send the message "I'm Alive!" to the channel the message was recieved from */
			await ctx.RespondAsync(string.Concat("I have absolutly no idea what you want... Here, you need help\r\n" + help));
		}
	}
}
