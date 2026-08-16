namespace DesignPatternChallenge;

// Director: centraliza "receitas" de relatórios com configurações comuns,
// evitando repetir a mesma sequência de chamadas em vários pontos do código.
public static class SalesReportDirector
{
    public static SalesReport RelatorioPadraoPdf(string titulo, DateTime inicio, DateTime fim)
    {
        return new SalesReportBuilder()
            .ComTitulo(titulo)
            .ComFormato("PDF")
            .ComPeriodo(inicio, fim)
            .ComColunas("Produto", "Quantidade", "Valor")
            .ComTotais()
            .Build();
    }
}
