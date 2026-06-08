using CustomDataScouting;
using System.Text;
using System.Text.RegularExpressions;

// 追加しないと言語設定の問題で正常に出力されない可能性がある。
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine($"Please select mode{Environment.NewLine}Mode1 :Original read{Environment.NewLine}Mode2 : PlayerStats read");
Console.WriteLine("1: Mode1, 2: Mode2, Other: End execution");
Console.Write("Input: ");
string mode = Console.ReadLine() ?? "";
string path = "";


if (mode == "1" || mode == "2")
{
    Console.WriteLine("Please input folder path");
    Console.Write("Input: ");
    path = @"" + Console.ReadLine() ?? "";
}

if (mode == "1")
{
    Console.WriteLine(readModeOne(path));
    return;

}
else if (mode == "2")
{
    Console.WriteLine(readModeTwo(path));
    return;

}
else
{
    Console.WriteLine("End execution");
    return;
}



static String readModeOne(string path)
{
    CustomDataScouting.CustomDataScouting customDataScouting = new CustomDataScouting.CustomDataScouting(path);
    var result = customDataScouting.ReadCSV();
    string returnText = "";

    foreach (var match in result)
    {
        foreach (var line in match)
            returnText += $"Rank: {line.Rank}, Team: {line.TeamName}, Nickname: {line.Nickname}, Character: {line.Subject}, Total Field Kill: {line.TotalFieldKill}, Total Score: {line.TournamentTotalScore}{Environment.NewLine}";
    }

    return returnText;

}

static String readModeTwo(string path)
{
    CustomDataScouting.CustomDataScouting customDataScouting = new CustomDataScouting.CustomDataScouting(path);
    var results = customDataScouting.ReadCSV();
    string returnText = "";

    foreach (var result in results)
    {
        IList<PlayerMatchData> matches = PlayerMatchData.CreatePlayerDatas(result);
        foreach (var match in matches)
        {
            returnText += $"{match.ToString()}{Environment.NewLine}";
        }
    }

    return returnText;

}
