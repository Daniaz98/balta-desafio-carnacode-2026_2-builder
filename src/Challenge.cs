// DESAFIO: Gerador de Relatórios Complexos
// PROBLEMA: Sistema precisa gerar diferentes tipos de relatórios (PDF, Excel, HTML)
// com múltiplas configurações opcionais (cabeçalho, rodapé, gráficos, tabelas, filtros)
// O código atual usa construtores enormes ou muitos setters, tornando difícil criar relatórios

using System;
using System.Collections.Generic;

namespace DesignPatternChallenge
{
    // Contexto: Sistema de BI que gera relatórios customizados para diferentes departamentos
    // Cada relatório pode ter dezenas de configurações opcionais

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Relatórios ===");

            var report = new SalesReportBuilder()
                .ComTitulo("Relatório de Vendas - Agosto")
                .ComFormato("PDF")
                .ComPeriodo(new DateTime(2026, 8, 1), new DateTime(2026, 8, 31))
                .ComColunas("Produto", "Quantidade", "Valor")
                .ComGraficos("Barras")
                .ComTotais()
                .Build();

            report.Generate();

            var report2 = new SalesReportBuilder()
                    .ComTitulo("Relatório Trimestral")
                    .ComFormato("Excel")
                    .ComPeriodo(new DateTime(2024, 1, 1), new DateTime(2024, 3, 31))
                    .ComColunas("Vendedor", "Região", "Total")
                    .ComGraficos("Linhas")
                    .AgrupadoPor("Região")
                    .ComTotais()
                    .Build();
            
            report2.Generate();
            
            var report3 = new SalesReportBuilder()
                .ComTitulo("Vendas Anuais")
                .ComFormato("PDF")
                .ComPeriodo(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31))
                .ComCabecalho("Relatório de Vendas")
                .ComRodape("Confidencial")
                .ComColunas("Produto", "Quantidade", "Valor")
                .ComGraficos("Pie")
                .ComTotais()
                .ComOrientacao("Landscape")
                .ComTamanhoPagina("A4")
                .Build();
            
            report3.Generate();

            var report4 = SalesReportDirector.RelatorioPadraoPdf("Vendas - Outubro", new DateTime(2025, 10, 1), new DateTime(2025, 10, 31));

            report4.Generate();

            // Perguntas para reflexão (respondidas pela solução implementada):
            //
            // - Como criar relatórios complexos sem construtores gigantes?
            //   R: Com o padrão Builder. Em vez de um construtor com dezenas de parâmetros,
            //   a construção é quebrada em métodos pequenos e nomeados (ComTitulo, ComPeriodo,
            //   ComGraficos...). Cada configuração opcional só aparece quando é usada: um
            //   relatório simples tem poucas chamadas, um complexo tem mais, e nenhum dos dois
            //   precisa passar parâmetros irrelevantes.
            //
            // - Como garantir que configurações obrigatórias sejam definidas?
            //   R: Em duas camadas. Em tempo de compilação: Title e Format são "required" no
            //   SalesReport e todas as propriedades usam "init", então não há como criar um
            //   relatório "vazio" por setters soltos — a única porta de entrada é o builder.
            //   Em runtime: o Build() valida título, formato, mínimo de colunas e coerência do
            //   período, falhando imediatamente com mensagem clara se algo faltar. Além disso,
            //   métodos como ComCabecalho(texto) agrupam configurações interdependentes
            //   (IncludeHeader + HeaderText), impossibilitando ligar o cabeçalho sem o texto.
            //
            // - Como reutilizar configurações comuns entre relatórios?
            //   R: Com o Director (SalesReportDirector), que centraliza "receitas" prontas de
            //   construção. RelatorioPadraoPdf() encapsula formato, colunas padrão e totais em
            //   uma única chamada (ver report4 acima). Novas receitas viram novos métodos, e
            //   mudanças na configuração padrão são feitas em um único lugar.
            //
            // - Como tornar o processo de criação mais legível e fluente?
            //   R: Todo método do builder retorna "this" (fluent interface), permitindo o
            //   encadeamento que se lê como uma frase. Os nomes expressam intenção de domínio
            //   (AgrupadoPor("Região")) em vez de mecânica (GroupBy = "Região"), e assinaturas
            //   convenientes como params em ComColunas(...) e o par de datas em ComPeriodo(...)
            //   eliminam ruído na chamada.
        }
    }
}
