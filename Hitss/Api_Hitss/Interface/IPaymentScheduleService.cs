using Api_Hitss.Model;

namespace Api_Hitss.Interface
{
    public interface IPaymentScheduleService
    {
        void Save(Proposta proposta, int id);
    }
}
