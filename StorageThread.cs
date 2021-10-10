using HaroldTheBot.Raids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public static class StorageThread
    {
        public static void Run()
        {
            while (true)
            {
                RaidStorage.SaveStorage();

                Thread.Sleep(5000);
            }
        }
    }
}
