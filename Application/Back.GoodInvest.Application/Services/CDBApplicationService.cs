using Back.GoodInvest.Application.DTOs.CDB;
using Back.GoodInvest.Application.Services.Interfaces;
using Back.GoodInvest.Domain.Core.Interfaces.Service;

namespace Back.GoodInvest.Application.Services
{
    public class CDBApplicationService : ICDBApplicationService
    {
        private readonly ISimulacaoService _simulacaoService;

        public CDBApplicationService(ISimulacaoService simulacaoService)
        {
            _simulacaoService = simulacaoService;
        }

        public async Task<SimulacaoResponse> CalcularRendimento(SimulacaoRequest request)
        {
            var resultado = await _simulacaoService.Simular(request.ValorInvestido, request.TaxaRendimento, request.PrazoDias, request.AporteMensal);

            return new SimulacaoResponse
            {
                Detalhamento = resultado.Rendimento.Detalhamento.Select(x => new DetalhamentoMes
                {
                    Data = x.Data,
                    SaldoBruto = x.SaldoBruto,
                    SaldoLiquido = x.SaldoLiquido
                }).ToList(),
                ValorBruto = resultado.Rendimento.ValorBruto,
                ValorLiquido = resultado.Rendimento.ValorLiquido,
                RendimentoPercentualLiquido = resultado.Rendimento.RendimentoPercentualLiquido
            };
        }
    }
}
