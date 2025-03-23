using Back.GoodInvest.Application.DTOs.CDB;
using Back.GoodInvest.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back.GoodInvest.API.Controllers
{
    /// <summary>
    /// CDB - Certificado de Depósito Bancário
    /// </summary>
    /// <param name="CDBApplicationService"></param>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CDBController(ICDBApplicationService CDBApplicationService) : ControllerBase
    {
        private readonly ICDBApplicationService _CDBApplicationService = CDBApplicationService;

        /// <summary>
        /// Realiza a simulação da rentabilidade de um investimento em CDB.
        /// </summary>
        /// <param name="request">Dados necessários para a simulação.</param>
        /// <returns>Resultado da simulação contendo valor final, rendimento bruto e líquido.</returns>
        [HttpPost("Simular")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SimulacaoResponse))]
        public async Task<ActionResult<SimulacaoResponse>> Simular(SimulacaoRequest request)
        {
            try
            {
                return Ok(await _CDBApplicationService.CalcularRendimento(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
