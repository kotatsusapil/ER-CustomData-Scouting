using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataScouting
{
    /// <summary>
    /// 1試合のプレイヤーデータを管理するインターフェース
    /// </summary>
    public abstract class AbstractPlayerMatchData
    {

        /// <summary>
        /// プレイヤー名
        /// </summary>
        public string PlayerName { get; internal set; }

        /// <summary>
        /// チーム名
        /// </summary>
        public string TeamName { get; internal set; }

        /// <summary>
        /// 実験体
        /// </summary>
        public SubjectName Subject { get; internal set; }
        
        /// <summary>
        /// 順位
        /// </summary>
        public int Rank { get; internal set; }

        /// <summary>
        /// 動物処置数
        /// </summary>
        public int Hunt { get; internal set; }

        /// <summary>
        /// チームでのKS
        /// </summary>
        public double TeamKillScore { get; internal set; }

        /// <summary>
        /// チームでのTS
        /// </summary>
        public double TeamTotalScore { get; internal set; }
        
        /// <summary>
        /// チームメンバーの実験体（1人目）
        /// </summary>
        public SubjectName TeamMemberSubject1 { get; internal set; }
        
        /// <summary>
        /// チームメンバーの実験体（2人目)
        /// </summary>
        public SubjectName TeamMemberSubject2 { get; internal set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="playerName">プレイヤー名</param>
        /// <param name="subject">実験体</param>
        /// <param name="rank">順位</param>
        /// <param name="hunt">動物処置数</param>
        /// <param name="teamKillScore">チームでのKS</param>
        /// <param name="teamTotalScore">チームでのTS</param>
        /// <param name="teamMemberSubject1">チームメンバーの実験体（1人目）</param>
        /// <param name="teamMemberSubject2">チームメンバーの実験体（2人目）</param>
        internal AbstractPlayerMatchData(string playerName, string teamName, SubjectName subject, int rank, int hunt, double teamKillScore, double teamTotalScore, SubjectName teamMemberSubject1, SubjectName teamMemberSubject2)
        {
            PlayerName = playerName;
            TeamName = teamName;
            Subject = subject;
            Rank = rank;
            Hunt = hunt;
            TeamKillScore = teamKillScore;
            TeamTotalScore = teamTotalScore;
            TeamMemberSubject1 = teamMemberSubject1;
            TeamMemberSubject2 = teamMemberSubject2;
        }

    }
}
