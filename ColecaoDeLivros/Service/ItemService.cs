using ColecaoDeItem.Models;
using ColecaoDeItem.Service.DTO;

namespace ColecaoDeItem.Service
{
    public class ItemService
    {
        
        public ValidadorDeItem EhValido()
        {
            Item item = new Item();
            
            if (string.IsNullOrWhiteSpace(item.Nome))
                return new ValidadorDeItem(false, "Por favor digite um nome válido!");

            if (string.IsNullOrWhiteSpace(item.Tipo))
                return new ValidadorDeItem(false, "Por favor digite um tipo válido!");

            if (item.Tipo.ToLower() != "livro" && item.Tipo.ToLower() != "cd" && item.Tipo.ToLower() != "dvd")
            {
                return new ValidadorDeItem(false, "Por favor inserir um tipo válido ( Livro, Cd ou Dvd)!");
            }
            else
                return new ValidadorDeItem(true, "Criado com sucesso!");
        }
    }
}
