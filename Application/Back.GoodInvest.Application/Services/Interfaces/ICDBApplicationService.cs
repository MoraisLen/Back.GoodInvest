using Back.GoodInvest.Application.DTOs.CDB;

namespace Back.GoodInvest.Application.Services.Interfaces
{
    public interface ICDBApplicationService
    {
        Task<SimulacaoResponse> CalcularRendimento(SimulacaoRequest request);
    }
}
