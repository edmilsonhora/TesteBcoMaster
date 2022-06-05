using System.Collections.Generic;
using TesteBancoMaster.ApplicationService.Views;
using TesteBancoMaster.DomainModel;

namespace TesteBancoMaster.ApplicationService.Adapters
{
    static class RotaAdapter
    {
        public static List<RotaView> ConvertToView(this List<Rota> list)
        {
            var novaLista = new List<RotaView>();

            foreach (var item in list)
            {
                novaLista.Add(item.ConvertToView());
            }

            return novaLista;
        }

        public static RotaView ConvertToView(this Rota item)
        {
            if (item == null)
                return new RotaView();

            return new RotaView()
            {
                Id = item.Id,
                Origem = item.Origem,
                Destino = item.Destino,
                Valor = item.Valor
            };

        }
    }
}
