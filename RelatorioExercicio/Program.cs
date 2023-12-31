using ClosedXML.Excel;

Console.Write("Enter file full path: ");
string path = Console.ReadLine();

var xls = new XLWorkbook(path);
var planilha = xls.Worksheets.First(x => x.Name == "Plan1");
var totalLinhas = planilha.Rows().Count();
Dictionary<string, int> candidates = new Dictionary<string, int>();

for (int i = 1; i <= totalLinhas; i++)
{
    var name = planilha.Cell($"A{i}").Value.ToString();
    var votes = int.Parse(planilha.Cell($"B{i}").Value.ToString());

    if(candidates.ContainsKey(name))
    {
        candidates[name] += votes;
    }
    else
    {
        candidates.Add(name, votes);
    }
}

foreach (var item in candidates)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}