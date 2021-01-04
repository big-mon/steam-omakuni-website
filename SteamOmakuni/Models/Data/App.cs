using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SteamOmakuni.Models.Data
{
    public class App
    {
        #region Props

        public string AppID { get; }
        public string Name { get; }
        public string Type { get; }
        public uint Recommendations { get; }
        public bool IsFree { get; }
        public List<string> Developers { get; }
        public List<string> Publishers { get; }
        public List<string> Languages { get; }
        public List<Genre> Genres { get; }
        public List<Price> Prices { get; }
        public Release Release { get; }

        #endregion

        /// <summary>コンストラクタ</summary>
        /// <param name="row">SQL取得結果行</param>
        public App(DataRow row)
        {
            AppID = row["appid"].ToString();
            Name = row["name"].ToString();
            Type = row["type"].ToString();
            Recommendations = (uint)row["recommendations"];
            IsFree = (bool)row["is_free"];
            Developers = row["developers"].ToString().Split(",").ToList();
            Publishers = row["publishers"].ToString().Split(",").ToList();
            Languages = row["languages"].ToString().Split(",").ToList();

            if ("" != row["genre_id"].ToString())
            {
                var tmpGenres = new List<Genre>();
                var ids = row["genre_id"].ToString().Split(",").ToList();
                var names = row["genre_name"].ToString().Split(",").ToList();
                for (int i = 0, j = ids.Count; i < j; i++)
                {
                    tmpGenres.Add(new Genre(ids[i], names[i]));
                }
                Genres = tmpGenres;
            }
            if ("" != row["currencys"].ToString())
            {
                var tmpPrices = new List<Price>();
                var cus = row["currencys"].ToString().Split(",").ToList();
                var ins = row["initials"].ToString().Split(",").Select(x => decimal.Parse(x)).ToList();
                var fis = row["finals"].ToString().Split(",").Select(x => decimal.Parse(x)).ToList();
                var dis = row["discount_percents"].ToString().Split(",").Select(x => int.Parse(x)).ToList();
                for (int i = 0, j = cus.Count; i < j; i++)
                {
                    tmpPrices.Add(new Price(cus[i], ins[i], fis[i], dis[i]));
                }
                Prices = tmpPrices;
            }
            if (null != row["date"]) Release = new Release((bool)row["comming_soon"], row["date"].ToString());
        }
    }
}
