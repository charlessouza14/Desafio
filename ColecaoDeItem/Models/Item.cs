using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Reflection.Metadata;

namespace ColecaoDeLivros.Models
{
    public class Item
    {
        public int Id { get; set; }     
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }       
        public DateTime UltimaAtualizacao { get; set; }         
        public Contato Contato { get; set; }
        
        public Item()
        {
            UltimaAtualizacao = DateTime.Now;     
            Status = "Disponível";  

        }

      
       
        

               
     
    }
    
}
