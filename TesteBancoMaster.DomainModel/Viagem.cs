using System;
using System.Linq;

namespace TesteBancoMaster.DomainModel
{
    public class Viagem : EntityBase
    {
        public override void Validar()
        {
            CampoTextObrigatorio(nameof(Origem), Origem);
            CampoTextObrigatorio(nameof(Destino), Destino);
            base.Validar();
        }

        public string CalcularMenorCusto(IRotaRepository repository)
        {
            string resultado = string.Empty;
            double valor = 0;
            Rota rotaDireta = repository.ObterComMenorValorPor(Origem, Destino);
            Rota rotaMinVal = new Rota();

            do
            {
                var rotasTemp = repository.ObterPor(Origem);
                rotasTemp.Remove(rotasTemp.Find(p => p.Id == rotaDireta?.Id));
                rotaMinVal = rotasTemp.OrderBy(p => p.Valor).FirstOrDefault();

                if (rotaMinVal == null && rotaDireta == null)
                {
                    throw new ApplicationException("Não existe rota disponivel para Origem/Destino informados.");
                }
                else if (rotaMinVal == null)
                {
                    rotaMinVal = rotaDireta;
                }

                resultado += $"{Origem} - ";
                valor += rotaMinVal.Valor;
                Origem = rotaMinVal.Destino;

            } while (Destino != rotaMinVal.Destino);

            if (rotaDireta != null && rotaDireta.Valor <= valor)
                return $"{rotaDireta.Origem} - {rotaDireta.Destino} ao custo de ${rotaDireta.Valor}";

            return $"{resultado}{Destino} ao custo de ${valor}";
        }
    }
}
