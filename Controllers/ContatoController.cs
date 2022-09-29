using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class ContatoController : Controller
    {

        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contatos = _context.Contatos.ToList();        
            return View(contatos); 
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar (Contato novoContato)
        {
            if (ModelState.IsValid)
            {
                _context.Contatos.Add(novoContato);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(novoContato);
        }

        public IActionResult Editar(int id)        
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null){
                return NotFound();
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato contatoAlterado)
        {
            var contato  = _context.Contatos.Find(contatoAlterado.Id);

            if (contato is null){
                return NotFound();
            }

            contato.Nome     = contatoAlterado.Nome;
            contato.Telefone = contatoAlterado.Telefone;
            contato.Ativo    = contatoAlterado.Ativo;

            _context.Contatos.Update(contato);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato is null){
                return NotFound();
            }

            return View(contato);
        }

        public IActionResult Deletar(int id){

            var contato = _context.Contatos.Find(id);

            if (contato is null){
              return NotFound();
            }

            return View(contato);
        }

         [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoDeletar = _context.Contatos.Find(contato.Id);

            if (contato is null){
                return NotFound();
            }

            _context.Contatos.Remove(contatoDeletar);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}