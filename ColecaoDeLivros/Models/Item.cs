using System.Reflection.Metadata;

namespace ColecaoDeLivros.Models
{
    public class Item
    {
        public int Id { get; set; }     
         public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        // usar o datetime como construtor
        public DateTime UltimaAtualizacao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public string Contato { get; set; }

        public Item()
        {
            DataDeCriacao = DateTime.Now;
            Status = "Disponível";
        }          
               
     
    }
    
}
