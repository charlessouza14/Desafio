using ColecaoDeItem.Models;

namespace ColecaoDeItem.Service.DTO
{
    public class ValidadorDeItem
    {
        public bool Status { get; set; }
        public string Mensagem { get; set; }


        public ValidadorDeItem(bool _status, string _parametro)
        {
            Status = _status;
            Mensagem = _parametro;
        }
 
        
    }
}
