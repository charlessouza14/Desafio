using Microsoft.AspNetCore.Mvc;

namespace ColecaoDeLivros.Models
{
    public class Contato 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Celular { get; set; }
        public string Endereco { get; set; }
    }
}
