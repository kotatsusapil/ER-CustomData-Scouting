using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataScouting
{
    /// <summary>
    /// CSVファイルの各行を表すクラス
    /// </summary>
    [Delimiter(",")]
    public class CustomCSVData
    {

        /// <summary>
        /// 順位
        /// </summary>
        [Name("rank")]
        public int Rank
        {
            get; set;
        }

        /// <summary>
        /// 実験体のレベル
        /// </summary>
        [Name("level")]
        public int Level { get; set; }

        /// <summary>
        /// 実験体名
        /// </summary>
        [Name("character")]
        public string Subject{get; set;}

        /// <summary>
        /// プレイヤー名
        /// </summary>
        [Name("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// 武器名
        /// </summary>
        [Name("weapon")]
        public string? Weapon { get; set; }

        /// <summary>
        /// 最大熟練度の項目
        /// </summary>
        [Name("best weapon mastery")]
        public string BestWeaponMastery { get; set; }

        /// <summary>
        /// 最大熟練度（最高20）
        /// </summary>
        [Name("best weapon mastery level")]
        public int BestWeaponMasteryLevel { get; set; }

        /// <summary>
        /// 合計FK
        /// </summary>
        [Name("total field kill")]
        public int TotalFieldKill { get; set; }

        /// <summary>
        /// 合計TK
        /// </summary>
        [Name("team kill")]
        public int TeamKill { get; set; }

        [Name("elimination")]
        public int Elimination { get; set; }

        /// <summary>
        /// 全滅しないタイミングのダウン数
        /// </summary>
        [Name("down can not eliminate")]
        public int DownCanNotEliminate { get; set; }

        /// <summary>
        /// 全滅しないタイミングにとどめを刺された数
        /// </summary>
        [Name("repeat down can not eliminate")]
        public int RepeatDownCanNotEliminate { get; set; }

        /// <summary>
        /// 全滅するタイミングのダウン数
        /// </summary>
        [Name("down can eliminate")]
        public int DownCanEliminate { get; set; }

        /// <summary>
        /// 全滅するタイミングにとどめを刺された数
        /// </summary>
        [Name("repeat down can eliminate")]
        public int RepeatDownCanEliminate { get; set; }

        /// <summary>
        /// 実験体処置数
        /// </summary>
        [Name("kill")]
        public int Kill { get; set; }

        /// <summary>
        /// 実験体処置のアシスト数
        /// </summary>
        [Name("assist")]
        public int Assist { get; set; }

        /// <summary>
        /// 野生動物のキル数
        /// </summary>
        [Name("hunting")]
        public int Hunting { get; set; }

        /// <summary>
        /// 処置したプレイヤー名
        /// </summary>
        [Name("killer")]
        public string? Killer { get; set; }

        /// <summary>
        /// 試合ID
        /// </summary>
        [Name("gameId")]
        public string GameId { get; set; }

        /// <summary>
        /// チーム名
        /// </summary>
        [Name("teamName")]
        public string TeamName { get; set; }

        /// <summary>
        /// 大会モードの合計スコア
        /// </summary>
        [Name("tournament total score")]
        public double TournamentTotalScore { get; set; }

        /// <summary>
        /// 大会スコアの順位スコア
        /// 現段階ではintで表現可能だが、今後のルール変更に備えてdouble型で定義している
        /// </summary>
        [Name("tournament rank score")]
        public double TournamentRankScore { get; set; }

        /// <summary>
        /// 大会スコアの合計キルポイント
        /// </summary>
        [Name("tournament kill score")]
        public double TournamentKillScore { get; set; }

        /// <summary>
        /// CSVを読み取った情報からチーム多淫委の情報に切り取る
        /// </summary>
        /// <param name="cSVData">CSVを読みとった情報</param>
        /// <returns>チーム名をKeyとした辞書</returns>
        internal static Dictionary<string, List<CustomCSVData>> getTeamData(IList<CustomCSVData> cSVData)
        {
            var grouped = cSVData.GroupBy(r => r.TeamName.TrimStart()).ToDictionary(g => g.Key, g => g.ToList());
            return grouped;
        }
    }
}
