using System.Text.Json;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // JSON 相對路徑
        string filePath = Path.Combine(AppContext.BaseDirectory, "App_Data", "affdata.json");

        Console.WriteLine("=== 河川水位測站基本資料讀取 ===\n");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"找不到 JSON 檔案：{filePath}");
            return;
        }

        string json = await File.ReadAllTextAsync(filePath);
        var stations = JsonSerializer.Deserialize<List<AffStation>>(json);

        if (stations == null || stations.Count == 0)
        {
            Console.WriteLine("JSON 檔案內沒有資料！");
            return;
        }

        Console.WriteLine($"成功讀取 {stations.Count} 筆資料。\n");

        // -------------------------
        // ⭐ 新增功能：搜尋測站名稱
        // -------------------------
        Console.Write("請輸入關鍵字以搜尋測站名稱：");
        string keyword = Console.ReadLine()?.Trim() ?? "";

        Console.WriteLine();

        // LINQ 搜尋
        var results = stations
            .Where(s => s.observatoryname != null &&
                        s.observatoryname.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("查無符合的測站。");
        }
        else
        {
            Console.WriteLine($"找到 {results.Count} 筆符合的資料：\n");

            foreach (var s in results)
            {
                Console.WriteLine($"測站名稱：{s.observatoryname}");
                Console.WriteLine($"測站代碼：{s.observatoryidentifier}");
                Console.WriteLine($"河川名稱：{s.rivername}");
                Console.WriteLine($"地點：{s.locationaddress}");
                Console.WriteLine($"狀態：{s.observationstatus}");
                Console.WriteLine("--------------------------------------------");
            }
        }

        Console.WriteLine("\n按任意鍵結束程式...");
        Console.ReadKey();
    }
}
