using Back.GoodInvest.Core.Calculo;
using Back.GoodInvest.Core.Entities;
using Back.GoodInvest.Domain.Core.Interfaces.Service;
using Back.GoodInvest.Domain.Entities;

namespace Back.GoodInvest.Domain.Service.Service
{
    public class SimulacaoService : ISimulacaoService
    {
        public async Task<ResultadoSimulacao> Simular(decimal valorInvestido, decimal taxaRendimento, int prazoDias, decimal aporteMensal)
        {
            if (valorInvestido <= 0)
                return new ResultadoSimulacao(false, "Valor investido deve ser maior que zero.");

            if (taxaRendimento <= 0)
                return new ResultadoSimulacao(false, "Taxa de rendimento deve ser maior que zero.");

            if (prazoDias <= 0)
                return new ResultadoSimulacao(false, "Prazo em dias deve ser maior que zero.");

            Parametros parametros = new Parametros()
            {
                prazoDias = prazoDias,
                taxaRendimento = taxaRendimento,
                valorInvestido = valorInvestido,
                aporteMensal = aporteMensal
            };

            RendimentoCalculado? resultado = CalculoCDB.CalcularRendimento(parametros);

            return resultado == null
            ? new ResultadoSimulacao(false, "Erro ao calcular o rendimento.")
            : new ResultadoSimulacao()
            {
                Success = true,
                Rendimento = resultado,
                Message = "Rendimento calculado com sucesso."
            };
        }
    }
}
