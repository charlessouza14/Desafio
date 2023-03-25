using ColecaoDeLivros.Data;
using ColecaoDeLivros.Models;
using ColecaoDeLivros.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ColecaoDeLivros.Controllers
{
    public class LivrosController : Controller
    {
        public IActionResult Index()
        {
            LivrosRepository livrosRepository = new LivrosRepository();
            var buscar = livrosRepository.BuscarTudo();
            ViewBag.Livros = buscar;
            return View("Index");
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
            LivrosRepository livrosRepository = new LivrosRepository();           
            livrosRepository.Adicionar(livros);            
            return RedirectToAction("Index");
        }

        public IActionResult GetForm(string nome)
        {
            LivrosRepository livrosRepository = new LivrosRepository();
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
            LivrosRepository livrosRepository = new LivrosRepository();
            var atualizar = livrosRepository.Buscar(id);
            ViewBag.Livro = atualizar;
            return View("EditarLivro");
        }
        public IActionResult Put(Item livros)
        {
            LivrosRepository livrosRepository = new LivrosRepository();
            var atualizar = livrosRepository.Atualizar(livros);           
            return RedirectToAction("Index","Livros");
        }

        public IActionResult Delete(int id)
        {
            LivrosRepository livrosRepository = new LivrosRepository();
            livrosRepository.Deletar(id);
            return RedirectToAction("Index");

        }
    }
}
