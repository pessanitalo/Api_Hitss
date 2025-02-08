using Api_Hitss.Context;
using Api_Hitss.Interface;
using Api_Hitss.Model;

namespace Api_Hitss.Repository
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly DataContext _context;

        public PropostaRepository(DataContext context)
        {
            _context = context;
        }

        public Proposta Create(Proposta proposta)
        {
            _context.Proposta.Add(proposta);
            _context.SaveChanges();
            return proposta;
        }
    }
}
