using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Decofe2017.Context;
using Decofe2017.Models;
using Decofe2017.ViewModels;

namespace Decofe2017.Controllers
{
    public class HomeController : Controller
    {
        private DecofeContext _db = new DecofeContext();

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                ViewBag.Erro = "Insira o CPF antes de prosseguir!";
                return View();
            }

            var usuario = _db.Avaliadores.FirstOrDefault(x => x.Cpf == cpf);
            if (usuario == null)
            {
                ViewBag.Erro = "CPF não encontrado!";
                return View();
            }

            return RedirectToAction("Index", new {avaliadorId = usuario.AvaliadorId});
        }

        public ActionResult Index(int avaliadorId)
        {
            return View(_db.Trabalhos.Where(x => x.AvaliadorId == avaliadorId).ToList());
        }

        public ActionResult Avaliar(int trabalhoId = 0, int avaliadorId = 0)
        {
            var avaliacao = new Avaliacao() {AvaliadorId = avaliadorId, TrabalhoId = trabalhoId};

            var avaliacaoJaSalva = _db.Avaliacoes.FirstOrDefault(x => x.TrabalhoId == trabalhoId && x.AvaliadorId == avaliadorId);

            if (avaliacaoJaSalva != null)
                avaliacao = avaliacaoJaSalva;                  

            return View(new AvaliacaoViewModel() { Trabalho =_db.Trabalhos.Find(trabalhoId), Avaliacao =  avaliacao});
        }

        [HttpPost]
        public ActionResult Avaliar(Avaliacao avaliacao)
        {
            if (ModelState.IsValid)
            {
                if (avaliacao.AvaliacaoId > 0)
                {
                    _db.Entry(avaliacao).State = EntityState.Modified;
                    _db.SaveChanges();

                    TempData["Sucesso"] = "Avaliação salva com sucesso.";
                }
                else
                {                    
                    _db.Avaliacoes.Add(avaliacao);
                    _db.SaveChanges();

                    TempData["Sucesso"] = "Avaliação editada com sucesso.";
                }

                return RedirectToAction("Index", new { avaliadorId = avaliacao.AvaliadorId});
                //return View(new AvaliacaoViewModel() { Avaliacao = new Avaliacao() { AvaliadorId = avaliacao.AvaliadorId, TrabalhoId = avaliacao.TrabalhoId }, Trabalho = _db.Trabalhos.Find(avaliacao.TrabalhoId) });
            }                                                                                                            
            
            return View(new AvaliacaoViewModel() { Avaliacao = new Avaliacao() { AvaliadorId = avaliacao.AvaliadorId, TrabalhoId = avaliacao.TrabalhoId }, Trabalho = _db.Trabalhos.Find(avaliacao.TrabalhoId)});
        }

        public ActionResult AusentarTrabalho(int trabalhoId, int avaliadorId, bool ausente)
        {
            var trabalho = _db.Trabalhos.Find(trabalhoId);
            trabalho.Ausente = ausente;
            _db.Entry(trabalho).State = EntityState.Modified;;
            _db.SaveChanges();

            TempData["Sucesso"] = "Trabalho ausentado com suceso!";

            return RedirectToAction("Avaliar", new {trabalhoId = trabalhoId, avaliadorId = avaliadorId});
        }
    }
}