using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;

namespace CustomDataScouting
{
    /// <summary>
    /// CSVファイルを読み込むためのクラス
    /// CsvDataクラスはCSVファイルの各行を表すためのクラスで、CsvHelperを使用してCSVファイルを読み込む際に使用される
    /// Eternal Returnでカスタムゲーム終了時に作成されるCSVファイルの構造のみ受け付ける
    /// </summary>
    internal class ReadCSV
    {
        /// <summary>
        /// CSVデータを読み込むメソッド
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>読み込んだデータを返却する。読み取りエラー時には空のリストを返す</returns>
        internal IList<CustomCSVData> ReadCsv(string filePath)
        {
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.Trim(), // ヘッダーの前後スペースを除去
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                try
                {
                    var records = csv.GetRecords<CustomCSVData>().ToList();
                    return (IList<CustomCSVData>)records; // 最初の行を返す
                }catch(Exception e){
                    Console.WriteLine($"CSVの読み込み中にエラーが発生しました: {e.Message}");
                    return new List<CustomCSVData>(); // 空のリストを返す
                }
            }
        }
    }
}

