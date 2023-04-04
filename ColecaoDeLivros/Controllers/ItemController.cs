using ColecaoDeLivros.Data;
using ColecaoDeLivros.Models;
using ColecaoDeLivros.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ColecaoDeLivros.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            ItemRepository itemRepository = new ItemRepository();
            var buscar = itemRepository.BuscarTudo();
            ViewBag.Livros = buscar;
            return View("Index");
        }
        
        public IActionResult ItemEmprestadoList()
        {
            ItemRepository itemRepository = new ItemRepository();
            var buscar = itemRepository.ItemEmprestado();
            ViewBag.Emprestado = buscar;
            return View("Emprestado");
        }       
        
        public IActionResult ItemEmprestadoForm()
        {
            return View("ItemAEmprestar");
        }
        public IActionResult PostForm()
        {
            return View("Post");
        }
        public IActionResult Post(Item livros)
        {
            if (livros == null)
            {
                return View("Por favor digite um nome válido");
            }
            ItemRepository livrosRepository = new ItemRepository();           
            livrosRepository.Adicionar(livros);            
            return RedirectToAction("Index");
        }

        public IActionResult GetForm(string nome)
        {
            ItemRepository livrosRepository = new ItemRepository();
            var buscarPorNome = livrosRepository.BuscarPessoa(nome);
            ViewBag.Nome = buscarPorNome;
            return View("BuscarPorNome");
        }
        //public IActionResult Get(int id)
        //{
        //    LivrosRepository livrosRepository = new LivrosRepository();
        //    var buscarPorId = livrosRepository.Buscar(id);
        //    ViewBag.Livros = buscarPorId;
        //    return RedirectToAction("Index","Livros");
        //}   

        public IActionResult PutForm(int id)
        {
            ItemRepository livrosRepository = new ItemRepository();
            var atualizar = livrosRepository.Buscar(id);
            ViewBag.Livro = atualizar;
            return View("EditarLivro");
        }
        public IActionResult Put(Item livros)
        {
            ItemRepository livrosRepository = new ItemRepository();
            var atualizar = livrosRepository.Atualizar(livros);           
            return RedirectToAction("Index","Livros");
        }

        public IActionResult Delete(int id)
        {
            ItemRepository livrosRepository = new ItemRepository();
            livrosRepository.Deletar(id);
            return RedirectToAction("Index");

        }
    }
}
