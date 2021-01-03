using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamOmakuni.Models.Data
{
    public class Release
    {
        public bool IsCommingSonn { get; }
        public string Date { get; }

        public Release(bool isCommingSoon, string date)
        {
            IsCommingSonn = isCommingSoon;
            Date = date;
        }
    }
}
