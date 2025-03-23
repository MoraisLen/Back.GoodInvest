using Back.GoodInvest.Domain.Entities;

namespace Back.GoodInvest.Domain.Core.Interfaces.Service
{
    public interface ISimulacaoService
    {
        Task<ResultadoSimulacao> Simular(decimal valorInvestido, decimal taxaRendimento, int prazoDias, decimal aporteMensal);
    }
}
