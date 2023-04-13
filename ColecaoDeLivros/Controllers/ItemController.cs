using ColecaoDeItem.Data;
using ColecaoDeItem.DTO;
using ColecaoDeItem.Models;
using ColecaoDeItem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ColecaoDeItem.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            ItemRepository itemRepository = new ItemRepository();
            var listaDeItem = itemRepository.BuscarTudo();
            ViewBag.Item = listaDeItem;
            return View("Index");
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
                return View("MensagemDeErro");
            }
            itemRepository.Adicionar(item);
            return RedirectToAction("Index");
        }

        public IActionResult Get(string nome)
        {
            ItemRepository itemRepository = new ItemRepository();           
            var buscarPorNome = itemRepository.BuscarItem(nome);
            if (buscarPorNome == null)
            {
                return View("MensagemDeErro");
            }
            if (string.IsNullOrWhiteSpace(nome))
            {
                return View("MensagemDeErro");
            }
            ViewBag.BuscarItem = buscarPorNome;
            return View("BuscarPorNome");
        }
        public IActionResult PutForm(int id)
        {            
            ItemRepository itemRepository = new ItemRepository();
            var atualizar = itemRepository.BuscarPorId(id);
            ViewBag.PutItem = atualizar;
            return View("EditarItem");
        }
        public IActionResult Put(Item item)
        {
            ItemRepository itemRepository = new ItemRepository();
            ValidadorDeItem validadorDeItem = item.EhValido();
            if (validadorDeItem.Status == false)
            {
                return View("MensagemDeErro");
            }
            var atualizar = itemRepository.Atualizar(item);           
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ItemRepository itemRepository = new ItemRepository();
            itemRepository.Deletar(id);
            return RedirectToAction("Index");

        }
    }
}
