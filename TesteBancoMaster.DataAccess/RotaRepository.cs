using System.Collections.Generic;
using System.Linq;
using TesteBancoMaster.DataAccess.Contextos;
using TesteBancoMaster.DomainModel;

namespace TesteBancoMaster.DataAccess
{
    public class RotaRepository : IRotaRepository
    {

        MyContext _context;
        public RotaRepository()
        {
            _context = new MyContext();
        }

        public void Excluir(Rota rota)
        {
            _context.Rotas.Remove(rota);
        }

        public Rota ObterPor(int id)
        {
            return _context.Rotas.FirstOrDefault(p => p.Id.Equals(id));
        }

        public Rota ObterComMenorValorPor(string origem, string destino)
        {
            return _context.Rotas.Where(p => p.Origem.Equals(origem) && p.Destino.Equals(destino)).OrderBy(p => p.Valor).FirstOrDefault();
        }

        public List<Rota> ObterPor(string origem)
        {
            return _context.Rotas.Where(p => p.Origem.Equals(origem)).ToList();
        }

        public List<Rota> ObterTodos()
        {
            return _context.Rotas.ToList();
        }

        public void Salvar(Rota rota)
        {
            if (rota.Id.Equals(0))
                _context.Rotas.Add(rota);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context = new MyContext();
        }

        public bool RotaExistente(Rota rota)
        {
            return _context.Rotas.Any(p => p.Origem.Equals(rota.Origem) && p.Destino.Equals(rota.Destino) && p.Id != rota.Id);
        }
    }
}
