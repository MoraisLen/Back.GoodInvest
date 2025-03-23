using Back.GoodInvest.Core.Entities;
using Back.GoodInvest.Domain.Entities;

namespace Back.GoodInvest.Core.Calculo
{
    public class CalculoCDB
    {
        // Método para calcular o rendimento de um CDB
        public static RendimentoCalculado? CalcularRendimento(Parametros parametros)
        {
            // Cálculo do valor bruto do CDB
            decimal valorBruto = parametros.valorInvestido * (decimal)Math.Pow((double)(1 + (parametros.taxaRendimento / 100)), parametros.prazoDias / 365.0);

            // Aplica o imposto de renda baseado no prazo
            decimal impostoDeRenda = CalcularImpostoDeRenda(valorBruto, parametros.valorInvestido, parametros.prazoDias);

            // Cálculo do valor líquido
            decimal valorLiquido = valorBruto - impostoDeRenda;

            // Calculando detalhamento mês a mês
            var detalhamento = new List<DetalhamentoMes>();

            for (int mes = 1; mes <= parametros.prazoDias / 30; mes++)  // Aproximadamente por mês
            {
                var saldoBruto = parametros.valorInvestido * (decimal)Math.Pow((double)(1 + (parametros.taxaRendimento / 100)), mes * 30 / 365.0);
                var saldoLiquido = saldoBruto - CalcularImpostoDeRenda(saldoBruto, parametros.valorInvestido, mes * 30);

                detalhamento.Add(new DetalhamentoMes
                {
                    Data = DateTime.Now.AddMonths(mes),
                    SaldoBruto = saldoBruto,
                    SaldoLiquido = saldoLiquido
                });
            }

            // Retorna a resposta com o valor bruto, líquido e detalhamento
            return new RendimentoCalculado
            {
                ValorBruto = valorBruto,
                ValorLiquido = valorLiquido,
                RendimentoPercentualLiquido = (valorLiquido - parametros.valorInvestido) / parametros.valorInvestido * 100,
                Detalhamento = detalhamento
            };
        }

        // Método para calcular o imposto de renda com base no prazo
        private static decimal CalcularImpostoDeRenda(decimal valorBruto, decimal valorInvestido, int prazoDias)
        {
            decimal aliquotaIr = 0;

            if (prazoDias <= 180)
                aliquotaIr = 0.225m; // 22.5% de IR
            else if (prazoDias <= 360)
                aliquotaIr = 0.20m; // 20% de IR
            else if (prazoDias <= 720)
                aliquotaIr = 0.175m; // 17.5% de IR
            else
                aliquotaIr = 0.15m; // 15% de IR

            // O imposto é calculado sobre o rendimento
            decimal rendimentoBruto = valorBruto - valorInvestido;  // Rendimento é o valor bruto menos o investido
            decimal imposto = rendimentoBruto * aliquotaIr;

            return imposto;
        }
    }
}
