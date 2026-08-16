namespace DesignPatternChallenge;

// Propriedades com "init": o relatório é imutável após a construção,
// forçando que toda criação passe pelo SalesReportBuilder (e suas validações).
public class SalesReport
{
    public required string Title { get; init; }
    public required string Format { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public bool IncludeHeader { get; init; }
    public bool IncludeFooter { get; init; }
    public string? HeaderText { get; init; }
    public string? FooterText { get; init; }
    public bool IncludeCharts { get; init; }
    public string? ChartType { get; init; }
    public bool IncludeSummary { get; init; }
    public List<string> Columns { get; init; } = new();
    public List<string> Filters { get; init; } = new();
    public string? SortBy { get; init; }
    public string? GroupBy { get; init; }
    public bool IncludeTotals { get; init; }
    public string? Orientation { get; init; }
    public string? PageSize { get; init; }
    public bool IncludePageNumbers { get; init; }
    public string? CompanyLogo { get; init; }
    public string? WaterMark { get; init; }

    public void Generate()
    {
        Console.WriteLine($"\n=== Gerando Relatório: {Title} ===");
        Console.WriteLine($"Formato: {Format}");
        Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");

        if (IncludeHeader)
            Console.WriteLine($"Cabeçalho: {HeaderText}");

        if (IncludeCharts)
            Console.WriteLine($"Gráfico: {ChartType}");

        Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");

        if (Filters.Count > 0)
            Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");

        if (!string.IsNullOrEmpty(GroupBy))
            Console.WriteLine($"Agrupado por: {GroupBy}");

        if (IncludeFooter)
            Console.WriteLine($"Rodapé: {FooterText}");

        Console.WriteLine("Relatório gerado com sucesso!");
    }
}
