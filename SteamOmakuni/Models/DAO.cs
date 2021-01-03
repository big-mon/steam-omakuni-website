using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SteamOmakuni.Models
{
    /// <summary>直接のDB接続を担当するクラス</summary>
    public static class DAO
    {
        #region SQL

        /// <summary>最新AppIDを取得</summary>
        private const string SQL_SELECT_NEW_APPS = @"
SELECT
  a.`appid`
  ,a.`name`
  ,a.`type`
  ,a.`is_free`
  ,r.`comming_soon`
  ,r.`date`
  ,GROUP_CONCAT(DISTINCT g.`id`) `genre_id`
  ,GROUP_CONCAT(DISTINCT g.`name`) `genre_name`
  ,GROUP_CONCAT(DISTINCT d.`name`) `developers`
  ,GROUP_CONCAT(DISTINCT pu.`name`) `publishers`
  ,GROUP_CONCAT(DISTINCT pr.`currency` ORDER BY pr.`currency` DESC) `currencys`
  ,GROUP_CONCAT(DISTINCT pr.`initial` ORDER BY pr.`currency` DESC) `initials`
  ,GROUP_CONCAT(DISTINCT pr.`final` ORDER BY pr.`currency` DESC) `finals`
  ,GROUP_CONCAT(DISTINCT pr.`discount_percent` ORDER BY pr.`currency` DESC) `discount_percents`
  ,GROUP_CONCAT(DISTINCT l.`name`) `languages`
FROM
  `apps` a
  RIGHT JOIN `releases` r
    ON a.`appid` = r.`appid`
  LEFT JOIN `genres` g
    ON a.`appid` = g.`appid`
  LEFT JOIN `developers` d
    ON a.`appid` = d.`appid`
  LEFT JOIN `publishers` pu
    ON a.`appid` = pu.`appid`
  LEFT JOIN `prices` pr
    ON a.`appid` = pr.`appid`
      AND pr.`currency` IS NOT NULL
  LEFT JOIN `languages` l
    ON a.`appid` = l.`appid`
      AND l.`appid` IS NOT NULL
WHERE
  a.`type` IN ('game', 'dlc', 'mod', 'music', 'video')
GROUP BY
  a.`appid`
ORDER BY
  a.`appid` DESC
LIMIT 0, 10
";

        #endregion

        /// <summary></summary>
        /// <returns></returns>
        public static DataTable RetrieveApps()
        {
            // DB接続
            using var conn = new MySqlConnection(GlobalConfigure.DbConnStr);
            conn.Open();

            // SQLの設定
            using var cmd = new MySqlCommand
            {
                Connection = conn,
                CommandText = SQL_SELECT_NEW_APPS
            };

            // SQL実行
            var dt = new DataTable();
            using var adp = new MySqlDataAdapter
            {
                SelectCommand = cmd
            };
            _ = adp.Fill(dt);

            return dt;
        }
    }
}
