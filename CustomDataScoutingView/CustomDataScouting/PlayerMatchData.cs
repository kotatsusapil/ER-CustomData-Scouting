using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomDataScouting
{
    /// <summary>
    /// 1試合のプレイヤーデータを管理するクラス
    /// </summary>
    public class PlayerMatchData : AbstractPlayerMatchData
    {
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
        internal PlayerMatchData(string playerName, string teamName,SubjectName subject, int rank, int hunt, double teamKillScore, double teamTotalScore, SubjectName teamMemberSubject1, SubjectName teamMemberSubject2)
            : base(playerName, teamName,subject, rank, hunt, teamKillScore, teamTotalScore, teamMemberSubject1, teamMemberSubject2)
        {
        }

        /// <summary>
        /// 1試合のデータから各プレイヤーのクラスを作成する
        /// </summary>
        /// <param name="cSVData">試合データ</param>
        /// <returns>プレイヤー情報</returns>
        public static IList<PlayerMatchData> CreatePlayerDatas(IList<CustomCSVData> cSVData)
        {
            var TeamData = CustomCSVData.getTeamData(cSVData);
            IList<PlayerMatchData> playerMatchDatas = new List<PlayerMatchData>();


            foreach (var playerData in cSVData)
            {
                IList<string> teamSubjects = GetTeamSubjects(TeamData[playerData.TeamName], playerData.Subject);

                try
                {
                    PlayerMatchData data = new PlayerMatchData(
                        playerData.Nickname,
                        playerData.TeamName,
                        PlayerMatchData.ConvertSubjectName(playerData.Subject),
                        playerData.Rank,
                        playerData.Hunting,
                        playerData.TournamentKillScore,
                        playerData.TournamentTotalScore,
                        PlayerMatchData.ConvertSubjectName(teamSubjects[0]),
                        PlayerMatchData.ConvertSubjectName(teamSubjects[1])
                    );
                    playerMatchDatas.Add(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine($"プレイヤー[{playerData.Nickname}]のデータ作成に失敗しました");
                }
            }

            return playerMatchDatas;
        }

        public override string ToString()
        {
            return $"Team: {TeamName}, PlayerName: {PlayerName}, Subject: {Subject.ToJapanese()}, Rank: {Rank}, Hunt: {Hunt}, TeamKillScore: {TeamKillScore}, TeamTotalScore: {TeamTotalScore}, TeamMemberSubject1: {TeamMemberSubject1.ToJapanese()}, TeamMemberSubject2: {TeamMemberSubject2.ToJapanese()}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static SubjectName ConvertSubjectName(string name)
        {

            if (Enum.TryParse<SubjectName>(name, out var result))
            {
                return result;
            }
            return SubjectName.Other;

        }


        internal static IList<string> GetTeamSubjects(List<CustomCSVData> teamDatas, string mySubject)
        { 
            List<string> subjects = new List<string>();
            foreach (var group in teamDatas)
            {
                if (group.Subject.ToString() != mySubject)
                {
                    subjects.Add(group.Subject.ToString());
                }
            }

            while (subjects.Count < 2)
            {
                subjects.Add("Other");
            }

            return subjects;

        }

    }
}
