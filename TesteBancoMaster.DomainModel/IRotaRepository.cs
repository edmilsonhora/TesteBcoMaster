using System.Collections.Generic;

namespace TesteBancoMaster.DomainModel
{
    public interface IRotaRepository
    {
        void Salvar(Rota rota);
        void Excluir(Rota rota);
        Rota ObterPor(int id);
        Rota ObterComMenorValorPor(string origem, string destino);
        bool RotaExistente(Rota rota);
        List<Rota> ObterPor(string origem);
        List<Rota> ObterTodos();
        void SaveChanges();
        void Rollback();
    }
}
