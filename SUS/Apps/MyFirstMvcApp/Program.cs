﻿using SUS.MVCFramework;
using System.Threading.Tasks;

namespace BattleCards
{
    public class Program
    {
        public static async Task Main(string[] args)
        {           
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}
