using System.Reflection.Metadata;

namespace ColecaoDeItem.Models
{
    public class ItemEmprestado : Item
    {       
      
        public ItemEmprestado(string nome, string tipo, string status)
        {
            nome = Nome;
            tipo = Tipo;
            status = Status;

            status = "Emprestado";
            UltimaAtualizacao = DateTime.Now;

        }
    }
}
