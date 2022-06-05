using System.Collections.Generic;
using TesteBancoMaster.ApplicationService.Views;

namespace TesteBancoMaster.ApplicationService
{
    public interface IRotaFacade
    {
        void Salvar(RotaView view);
        void Excluir(int id);
        RotaView ObterPor(int id);       
        List<RotaView> ObterTodos();
        string CalcularMenorCustoPara(ViagemView view);
        void SaveChanges();
        void Rollback();
    }
}
