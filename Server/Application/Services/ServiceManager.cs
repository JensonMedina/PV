using Application.Interfaces;

namespace Application.Services
{
    public class ServiceManager : IServiceManager
    {
        public IRubroService RubroService { get; }
        public IPlanSaasService PlanSaasService { get; }
        public IMedioPagoService MedioPagoService { get; }
        public INegocioService NegocioService { get; }

        public ServiceManager(
            IRubroService rubroService,
            IPlanSaasService planSaasService,
            IMedioPagoService medioPagoService,
            INegocioService negocioService)
        {
            RubroService = rubroService;
            PlanSaasService = planSaasService;
            MedioPagoService = medioPagoService;
            NegocioService = negocioService;
        }
    }

}
