namespace Application.Interfaces
{
    public interface IServiceManager
    {
        public IRubroService RubroService { get; }
        public IPlanSaasService PlanSaasService { get; }
        public IMedioPagoService MedioPagoService { get; }
        public INegocioService NegocioService { get; }
    }
}
