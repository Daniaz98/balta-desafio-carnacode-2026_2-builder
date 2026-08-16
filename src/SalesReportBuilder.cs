namespace DesignPatternChallenge;

public class SalesReportBuilder
{
    private string? _title;
    private string? _format;
    private DateTime _startDate;
    private DateTime _endDate;
    private bool _includeHeader;
    private string? _headerText;
    private bool _includeFooter;
    private string? _footerText;
    private bool _includeCharts;
    private string? _chartType;
    private List<string> _columns = new();
    private List<string> _filters = new();
    private string? _sortBy;
    private string? _groupBy;
    private bool _includeTotals;
    private string? _orientation;
    private string? _pageSize;
    private bool _includePageNumbers;
    private string? _companyLogo;
    private string? _waterMark;

    public SalesReport Build()
    {
        if (string.IsNullOrEmpty(_title))
            throw new InvalidOperationException("Título é obrigatório!");
        if (string.IsNullOrEmpty(_format))
            throw new InvalidOperationException("Formato é obrigatório!");
        if (_columns.Count < 2)
            throw new InvalidOperationException("Informe ao menos duas colunas.");
        if (_startDate == default || _endDate == default)
            throw new InvalidOperationException("Período é obrigatório.");
        if (_endDate < _startDate)
            throw new InvalidOperationException("Data final não pode ser anterior à data inicial.");

        // Cria uma instância nova a cada Build: o builder pode ser reutilizado
        // sem que alterações posteriores afetem relatórios já construídos.
        return new SalesReport
        {
            Title = _title,
            Format = _format,
            StartDate = _startDate,
            EndDate = _endDate,
            IncludeHeader = _includeHeader,
            HeaderText = _headerText,
            IncludeFooter = _includeFooter,
            FooterText = _footerText,
            IncludeCharts = _includeCharts,
            ChartType = _chartType,
            Columns = new List<string>(_columns),
            Filters = new List<string>(_filters),
            SortBy = _sortBy,
            GroupBy = _groupBy,
            IncludeTotals = _includeTotals,
            Orientation = _orientation,
            PageSize = _pageSize,
            IncludePageNumbers = _includePageNumbers,
            CompanyLogo = _companyLogo,
            WaterMark = _waterMark
        };
    }

    public SalesReportBuilder ComTitulo(string title)
    {
        _title = title;
        return this;
    }

    public SalesReportBuilder ComFormato(string format)
    {
        _format = format;
        return this;
    }

    public SalesReportBuilder ComPeriodo(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
        return this;
    }

    public SalesReportBuilder ComCabecalho(string headerText)
    {
        _includeHeader = true;
        _headerText = headerText;
        return this;
    }

    public SalesReportBuilder ComRodape(string footerText)
    {
        _includeFooter = true;
        _footerText = footerText;
        return this;
    }

    public SalesReportBuilder ComGraficos(string chartType)
    {
        _includeCharts = true;
        _chartType = chartType;
        return this;
    }

    public SalesReportBuilder ComColunas(params string[] columns)
    {
        _columns = columns.ToList();
        return this;
    }

    public SalesReportBuilder ComFiltros(params string[] filters)
    {
        _filters = filters.ToList();
        return this;
    }

    public SalesReportBuilder AgrupadoPor(string groupBy)
    {
        _groupBy = groupBy;
        return this;
    }

    public SalesReportBuilder OrdenadoPor(string sortBy)
    {
        _sortBy = sortBy;
        return this;
    }

    public SalesReportBuilder ComTotais()
    {
        _includeTotals = true;
        return this;
    }

    public SalesReportBuilder ComOrientacao(string orientation)
    {
        _orientation = orientation;
        return this;
    }

    public SalesReportBuilder ComTamanhoPagina(string pageSize)
    {
        _pageSize = pageSize;
        return this;
    }

    public SalesReportBuilder ComNumeracaoPaginas()
    {
        _includePageNumbers = true;
        return this;
    }

    public SalesReportBuilder ComLogo(string companyLogo)
    {
        _companyLogo = companyLogo;
        return this;
    }

    public SalesReportBuilder ComMarcaDagua(string waterMark)
    {
        _waterMark = waterMark;
        return this;
    }
}
