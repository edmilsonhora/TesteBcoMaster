using System.Collections.Generic;
using TesteBancoMaster.ApplicationService.Adapters;
using TesteBancoMaster.ApplicationService.Views;
using TesteBancoMaster.DataAccess;
using TesteBancoMaster.DomainModel;

namespace TesteBancoMaster.ApplicationService
{
    public class RotaFacade : IRotaFacade
    {
        private readonly IRotaRepository _repository;
        public RotaFacade()
        {
            _repository = new RotaRepository();
        }

        public string CalcularMenorCustoPara(ViagemView view)
        {
            var viagem = new Viagem();
            viagem.Origem = view.Origem;
            viagem.Destino = view.Destino;
            viagem.Validar();
            return viagem.CalcularMenorCusto(_repository);
        }

        public void Excluir(int id)
        {
            var rota = _repository.ObterPor(id);
            if (rota != null)
                _repository.Excluir(rota);
        }

        public RotaView ObterPor(int id)
        {
            return _repository.ObterPor(id).ConvertToView();
        }

        public List<RotaView> ObterTodos()
        {
            return _repository.ObterTodos().ConvertToView();
        }

        public void Salvar(RotaView view)
        {
            var rota = view.Id == 0 ? new Rota() : _repository.ObterPor(view.Id);
            rota.Origem = view.Origem;
            rota.Destino = view.Destino;
            rota.Valor = view.Valor;
            rota.Repository = _repository;
            rota.Validar();

            _repository.Salvar(rota);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        public void Rollback()
        {
            _repository.Rollback();
        }
    }
}
