namespace Back.GoodInvest.Domain.Entities
{
    public class ResultadoSimulacao
    {
        public ResultadoSimulacao() { }

        public ResultadoSimulacao(bool Success, string Message)
        {
            this.Success = Success;
            this.Message = Message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public RendimentoCalculado Rendimento { get; set; }
    }
}
