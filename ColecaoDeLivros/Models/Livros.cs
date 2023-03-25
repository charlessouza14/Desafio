using System.Reflection.Metadata;

namespace ColecaoDeLivros.Models
{
    public class Livros
    {
        public int Id { get; set; }
        public string Fornecedor { get; set; }
        public string Recebedor { get; set; }
        public string NomeDoItem { get; set; }
        public string Item { get; set; }
        public string Status { get; set; }
        // usar o datetime como construtor
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;      
        public Contato Contato { get; set; }   
        
               
        //public void AtualizarLivro(string fornecedor, string recebedor, string nomeDoItem, string item, string status, DateTime dataEmprestimo)
        //{
        //    Fornecedor = fornecedor;
        //    Recebedor = recebedor;
        //    NomeDoItem = nomeDoItem;
        //    Item = item;
        //    Status = status;
        //    DataEmprestimo = dataEmprestimo;
        //}
    }
    
}
