using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamOmakuni.Models.Data
{
    public class App
    {
        public string AppID { get; }
        public string Name { get; }
        public string Type { get; }
        public uint Recommendations { get; }
        public bool IsFree { get; }
        public List<string> Developers { get; }
        public List<string> Publishers { get; }
        public List<Genre> Genres { get; }
        public List<string> Languages { get; }
        public List<Price> Prices { get; }
        public Release Release { get; }
    }
}
