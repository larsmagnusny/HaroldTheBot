using HaroldTheBot.Data;
using HaroldTheBot.Raids;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HaroldDbContext>();
            services.AddScoped<IRaidRepository, RaidRepository>();
            services.AddScoped<IRaidService, RaidService>();
            services.AddScoped<IRaidMonitorer, RaidMonitorer>();
            services.AddScoped<IMessageMonitorer, MessageMonitorer>();
        }
    }
}
