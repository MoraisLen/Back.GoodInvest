namespace Back.GoodInvest.Application.DTOs.CDB
{
    /// <summary>
    /// Representa o resultado da simulação de um investimento em CDB.
    /// </summary>
    public class SimulacaoResponse
    {
        /// <summary>
        /// Valor total do investimento antes dos descontos de imposto de renda.
        /// </summary>
        /// <example>13500.00</example>
        /// <remarks>Este campo representa o valor bruto acumulado após o período de simulação.</remarks>
        public decimal ValorBruto { get; set; }

        /// <summary>
        /// Valor final do investimento após o desconto do imposto de renda.
        /// </summary>
        /// <example>12750.00</example>
        /// <remarks>Este campo representa o valor líquido após a dedução dos impostos.</remarks>
        public decimal ValorLiquido { get; set; }

        /// <summary>
        /// Percentual de rendimento líquido no período.
        /// </summary>
        /// <example>27.5</example>
        /// <remarks>Este campo indica o percentual de rendimento líquido obtido após o imposto.</remarks>
        public decimal RendimentoPercentualLiquido { get; set; }

        /// <summary>
        /// Detalhamento mês a mês com a evolução do saldo bruto e líquido.
        /// </summary>
        /// <remarks>Este campo contém a lista de detalhamento do saldo bruto e líquido para cada mês.</remarks>
        public List<DetalhamentoMes> Detalhamento { get; set; }
    }
}
