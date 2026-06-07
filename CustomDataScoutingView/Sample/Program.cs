Console.WriteLine($"Please select mode{Environment.NewLine}Mode1 :Original read{Environment.NewLine}Mode2 : PlayerStats read");
Console.WriteLine("1: Mode1, 2: Mode2, Other: End execution");
Console.Write("Input: ");
string mode = Console.ReadLine() ?? "";
string path = "";


if(mode == "1" || mode == "2"){
    Console.WriteLine("Please input folder path");
    Console.Write("Input: ");
    path = @"" + Console.ReadLine() ?? "";
}

if (mode == "1"){
    Console.WriteLine(readModeOne(path));
    return;

}
else if(mode == "2")
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

    foreach(var match in result)
    {
        foreach (var line in match)
        {
            returnText += $"Rank: {line.Rank}, Team: {line.TeamName}, Nickname: {line.Nickname}, Character: {line.Character}, Total Field Kill: {line.TotalFieldKill}, Total Score: {line.TournamentTotalScore}{Environment.NewLine}";
        }
    }

    return returnText;

}

static String readModeTwo(string path)
{
    return "";

}
