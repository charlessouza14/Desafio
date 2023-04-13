using ColecaoDeItem.Data;
using ColecaoDeItem.DTO;
using ColecaoDeItem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Immutable;

namespace ColecaoDeItem.Repository
{
    public class ItemRepository : ControllerBase
    { 
        public List<Item> BuscarTudo()
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.Item.ToList();
            return buscar;
        }

        public void Adicionar (Item item)
        {
            Contexto contexto = new Contexto();          
            contexto.Item.Add(item);            
            contexto.SaveChanges();            
        }

        public Item BuscarPorId(int id)
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.Item.FirstOrDefault(x => x.Id == id);
            return buscar;

        }
        public Item BuscarItem(string nome)
        {
            // idéia aqui era usar o Find (x => x.Nome.ToLower() == nome || x.Tipo.ToLower() == nome || x.Status.ToLower() == nome).ToList();
            Contexto contexto = new Contexto();
            var buscar = contexto.Item.FirstOrDefault(x => x.Nome.ToLower() == nome || x.Tipo.ToLower() == nome || x.Status.ToLower() == nome);
            return buscar;

        }     
        
        public Item Atualizar(Item item)
        {
            Contexto contexto = new Contexto();
            var atualizar = contexto.Item.FirstOrDefault(x => x.Id == item.Id);
            atualizar.Nome = item.Nome;
            atualizar.Tipo = item.Tipo;                                  
            contexto.Item.Update(atualizar);
            contexto.SaveChanges();
            return atualizar;
        }

        public void Deletar(int id)
        {
            Contexto contexto = new Contexto();
            var deletar = contexto.Item.FirstOrDefault(x => x.Id==id);
            contexto.Item.Remove(deletar);
            contexto.SaveChanges();            
        }



    }
}
