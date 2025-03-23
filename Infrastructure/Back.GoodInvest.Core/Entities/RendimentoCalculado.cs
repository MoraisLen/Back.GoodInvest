namespace Back.GoodInvest.Domain.Entities
{
    public class RendimentoCalculado
    {
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal RendimentoPercentualLiquido { get; set; }
        public List<DetalhamentoMes> Detalhamento { get; set; }
    }
}
