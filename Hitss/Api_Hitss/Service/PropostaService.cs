using Api_Hitss.Context;
using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Service
{
    public class PropostaService : IPropostaService
    {
        public readonly IPropostaRepository _repository;

        public PropostaService(IPropostaRepository repository)
        {
            _repository = repository;
        }

        public Proposta Create(Proposta proposta)
        {
           var novaProposta = _repository.Create(proposta);
           return novaProposta;
        }
    }
}
