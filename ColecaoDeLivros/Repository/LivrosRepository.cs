using ColecaoDeLivros.Data;
using ColecaoDeLivros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ColecaoDeLivros.Repository
{
    public class LivrosRepository : ControllerBase
    { 
        public List<Item> BuscarTudo()
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.Livros.ToList();
            return buscar;
        }

        public void Adicionar (Item emprestimos)
        {
            Contexto contexto = new Contexto();
            contexto.Livros.Add(emprestimos);
            contexto.SaveChanges();            
        }

        public Item Buscar(int id)
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.Livros.FirstOrDefault(x => x.Id == id);
            return buscar;

        }
        public Contato BuscarPessoa(string nome)
        {
            Contexto contexto = new Contexto();
            var buscar = contexto.Contato.FirstOrDefault(x => x.Nome == nome);
            return buscar;
        }     
        
        public Item Atualizar(Item emprestimo)
        {
            Contexto contexto = new Contexto();
            var atualizar = contexto.Livros.FirstOrDefault(x => x.Id == emprestimo.Id);
            atualizar.Recebedor = emprestimo.Recebedor;
            atualizar.Fornecedor = emprestimo.Fornecedor;
            atualizar.NomeDoItem = emprestimo.NomeDoItem;
            atualizar.Item = emprestimo.Item;
            atualizar.Status = emprestimo.Status;
            atualizar.DataEmprestimo = emprestimo.DataEmprestimo;
            //atualizar.AtualizarLivro(emprestimo.Fornecedor, emprestimo.Recebedor, emprestimo.NomeDoItem, emprestimo.Item, emprestimo.Status, emprestimo.DataEmprestimo);
            contexto.Livros.Update(atualizar);
            contexto.SaveChanges();
            return atualizar;
        }

        public void Deletar(int id)
        {
            Contexto contexto = new Contexto();
            var deletar = contexto.Livros.FirstOrDefault(x => x.Id==id);
            contexto.Livros.Remove(deletar);
            contexto.SaveChanges();            
        }



    }
}
