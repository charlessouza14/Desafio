using ColecaoDeLivros.Data;
using ColecaoDeLivros.DTO;
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
        public IActionResult Post(Item item)
        {
            ItemRepository itemRepository = new ItemRepository();            
            ValidadorDeItem validadorDeItem = item.EhValido();            
            if (validadorDeItem.Status == false)
            {
                return BadRequest(validadorDeItem.Mensagem);
            }
            if (item.Tipo.ToLower() == "livro")   
            {
                itemRepository.Adicionar(item);
                return RedirectToAction("Index");
            }
            else if (item.Tipo.ToLower() == "cd")
            {
            }
            else if (item.Tipo.ToLower() == "dvd")
            {
            }
            else
            {
                return BadRequest("Por favor inserir um tipo válido ( Livro, Cd ou Dvd)!");
            }
            itemRepository.Adicionar(item);            
            return RedirectToAction("Index");
        }

        public IActionResult GetForm(string nome)
        {
            ItemRepository itemRepository = new ItemRepository();           
            var buscarPorNome = itemRepository.BuscarPessoa(nome);
            if (buscarPorNome == null)
            {
                return BadRequest("Item não encontrado, por favor tente outro!");
            }
            if (string.IsNullOrWhiteSpace(nome))
            {
                return BadRequest("Item não encontrado, por favor tente outro!");
            }
            ViewBag.BuscarItem = buscarPorNome;
            return View("BuscarPorNome");
        }    

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
            ValidadorDeItem validadorDeItem = livros.EhValido();
            if (validadorDeItem.Status == false)
            {
                return BadRequest(validadorDeItem.Mensagem);
            }
            var atualizar = livrosRepository.Atualizar(livros);           
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ItemRepository livrosRepository = new ItemRepository();
            livrosRepository.Deletar(id);
            return RedirectToAction("Index");

        }
    }
}
