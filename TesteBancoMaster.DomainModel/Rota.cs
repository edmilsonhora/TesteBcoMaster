using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBancoMaster.DomainModel
{
    public class Rota : EntityBase
    {
        public int Id { get; set; }
        public double Valor { get; set; }

        [NotMapped]
        public IRotaRepository Repository { get; set; }

        public override void Validar()
        {

            CampoTextObrigatorio(nameof(Origem), Origem);
            CampoTextObrigatorio(nameof(Destino), Destino);
            CampoNumericoMaiorQueZero(nameof(Valor), Valor);
            if (Repository.RotaExistente(this))
                regrasQuebradas.Append($"Esta rota já esta cadastrada.{Environment.NewLine}");
            base.Validar();
        }



    }
}
