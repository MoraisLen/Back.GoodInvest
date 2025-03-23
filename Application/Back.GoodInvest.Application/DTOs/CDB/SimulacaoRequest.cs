namespace Back.GoodInvest.Application.DTOs.CDB
{
    /// <summary>
    /// Representa os dados necessários para simulação de um investimento em CDB.
    /// </summary>
    public class SimulacaoRequest
    {
        /// <summary>
        /// Valor inicial do investimento.
        /// </summary>
        /// <example>10000.00</example>
        /// <remarks>Este campo é obrigatório e representa o valor que será inicialmente investido.</remarks>
        public decimal ValorInvestido { get; set; }

        /// <summary>
        /// Taxa de rendimento do CDB.
        /// </summary>
        /// <example>105.0</example>
        /// <remarks>Este campo é obrigatório. Exemplo: 105% do CDI ou 12% ao ano.</remarks>
        public decimal TaxaRendimento { get; set; }

        /// <summary>
        /// Tipo de taxa: "CDI" ou "PRE" (prefixado).
        /// </summary>
        /// <example>"CDI"</example>
        /// <remarks>Este campo é obrigatório e indica o tipo de taxa do CDB. 
        /// CDI é uma taxa variável, enquanto PRE é uma taxa fixa.</remarks>
        public string TipoTaxa { get; set; }

        /// <summary>
        /// Data de início do investimento no formato YYYY-MM-DD.
        /// </summary>
        /// <example>"2025-01-01"</example>
        /// <remarks>Este campo é obrigatório e indica a data em que o investimento será iniciado.</remarks>
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// Prazo total do investimento em dias corridos.
        /// </summary>
        /// <example>720</example>
        /// <remarks>Este campo é obrigatório e define o prazo total do investimento em dias corridos.</remarks>
        public int PrazoDias { get; set; }

        /// <summary>
        /// Valor que será investido mensalmente durante o período do investimento.
        /// </summary>
        /// <example>500.00</example>
        /// <remarks>Este campo é opcional e, se informado, será considerado como aporte mensal.</remarks>
        public decimal AporteMensal { get; set; }
    }
}
