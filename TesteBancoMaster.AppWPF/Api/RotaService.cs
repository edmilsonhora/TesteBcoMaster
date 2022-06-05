using System.Collections.Generic;
using TesteBancoMaster.AppWPF.Api.Modelos;

namespace TesteBancoMaster.AppWPF.Api
{
    class RotaService : ServiceBase
    {
        public string CalcularMenorCustoPara(ViagemView view)
        {
            var response = RequisicaoPost("Rotas/CalcularMenorCusto", view);
            return ObterResposta<string>(response);
        }

        public void Excluir(int id)
        {
            RequisicaoGet($"Rotas/Excluir/{id}");
        }

        public RotaView ObterPor(int id)
        {
            var response = RequisicaoGet($"Rotas/ObterPor/{id}");
            return ObterResposta<RotaView>(response);
        }

        public List<RotaView> ObterTodos()
        {
            var response = RequisicaoGet($"Rotas/ObterTodos");
            return ObterResposta<List<RotaView>>(response);
        }

        public void Salvar(RotaView view)
        {
            RequisicaoPost("Rotas/Salvar", view);
        }
    }
}
