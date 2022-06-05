using System;
using System.Text;

namespace TesteBancoMaster.DomainModel
{
    public abstract class EntityBase
    {
        protected StringBuilder regrasQuebradas = new StringBuilder();
        public string Origem { get; set; }
        public string Destino { get; set; }
        public virtual void Validar()
        {
            if (regrasQuebradas.Length > 0)
                throw new ApplicationException(regrasQuebradas.ToString());
        }

        protected void CampoTextObrigatorio(string nomeDoCampo, string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                regrasQuebradas.Append($"O campo {nomeDoCampo} é obrigatório.{Environment.NewLine}");
        }

        protected void CampoNumericoMaiorQueZero(string nomeDoCampo, double valor)
        {
            if (valor < 1)
                regrasQuebradas.Append($"O campo {nomeDoCampo} tem que ser maior que zero.{Environment.NewLine}");
        }
    }
}
