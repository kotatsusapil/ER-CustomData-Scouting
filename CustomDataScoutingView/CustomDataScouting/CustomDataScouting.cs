namespace CustomDataScouting
{
    /// <summary>
    /// データ取得を行うためのクラス
    /// 上位ライブラリとの橋渡しを行うI/Fの役割を持つ
    /// </summary>
    public class CustomDataScouting
    {
        /// <summary>
        /// 読み込むフォルダのパス
        /// </summary>
        private string folderPath;



        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="folderPath">データを読み取るフォルダのパス</param>
        public CustomDataScouting(string folderPath)
        {
            this.folderPath = folderPath;
        }

        /// <summary>
        /// CSVデータを取得する
        /// </summary>
        /// <returns>CSVデータのリスト。【1:1試合のデータ】【2:試合内の1行ごとのデータ】</returns>
        /// <exception cref="DirectoryNotFoundException">指定したディレクトリが存在しない場合</exception>
        public IList<IList<CustomCSVData>> ReadCSV()
        {
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"Directory Not Found: {folderPath}");
            }
            var csvFiles = Directory.GetFiles(folderPath, "*.csv");
            Console.WriteLine($"Found {csvFiles.Length}");
            var readCSV = new ReadCSV();
            var allData = new List<IList<CustomCSVData>>();
            foreach (var file in csvFiles)
            {
                IList<CustomCSVData> data = readCSV.ReadCsv(file);
                if (data != null && data.Count() <= 0)
                {
                    continue;
                }

                allData.Add(data);
            }
            return allData;
        }
    }
}