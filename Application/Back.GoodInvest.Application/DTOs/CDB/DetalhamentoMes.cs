namespace Back.GoodInvest.Application.DTOs.CDB
{
    /// <summary>
    /// Representa o detalhamento mensal do saldo bruto e líquido.
    /// </summary>
    public class DetalhamentoMes
    {
        /// <summary>
        /// Data do mês para o qual o saldo é calculado.
        /// </summary>
        /// <example>"2025-02-01"</example>
        /// <remarks>Este campo representa a data de referência para o saldo do mês.</remarks>
        public DateTime Data { get; set; }

        /// <summary>
        /// Saldo bruto do investimento no mês.
        /// </summary>
        /// <example>10250.00</example>
        /// <remarks>Este campo representa o valor bruto do investimento após o período de um mês.</remarks>
        public decimal SaldoBruto { get; set; }

        /// <summary>
        /// Saldo líquido do investimento no mês após imposto de renda.
        /// </summary>
        /// <example>10175.00</example>
        /// <remarks>Este campo representa o valor líquido do investimento após o desconto de imposto de renda.</remarks>
        public decimal SaldoLiquido { get; set; }
    }
}
