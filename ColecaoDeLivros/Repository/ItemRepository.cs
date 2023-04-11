using ColecaoDeLivros.Data;
using ColecaoDeLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Immutable;

namespace ColecaoDeLivros.Repository
{
    public class ItemRepository : ControllerBase
    { 
        public List<Item> BuscarTudo()
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.Item.ToList();
            return buscar;
        }

        public List<ItemEmprestado> ItemEmprestado()
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.ItemEmprestado.ToList();
            return buscar;
        }

        public void Adicionar (Item item)
        {
            Contexto contexto = new Contexto();          
            contexto.Item.Add(item);            
            contexto.SaveChanges();            
        }

        public Item Buscar(int id)
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.Item.FirstOrDefault(x => x.Id == id);
            return buscar;

        }
        public Item BuscarPessoa(string nome)
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.Item.First(x => x.Nome.ToLower() == nome || x.Tipo.ToLower() == nome || x.Status.ToLower() == nome);
            return buscar;

        }     
        
        public Item Atualizar(Item emprestimo)
        {
            Contexto contexto = new Contexto();
            var atualizar = contexto.Item.FirstOrDefault(x => x.Id == emprestimo.Id);
            atualizar.Nome = emprestimo.Nome;
            atualizar.Tipo = emprestimo.Tipo;                                  
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
