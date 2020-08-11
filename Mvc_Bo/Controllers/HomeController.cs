using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc_Bo.Models;
using Mvc_Bo.Services;

namespace Mvc_Bo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {


            _logger = logger;
        }

        public IActionResult Index()
        {
            AlunoBll _aluno = new AlunoBll();
            List<Aluno> alunos = _aluno.GetAlunos().ToList();
            return View("Lista", alunos);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            //if (string.IsNullOrEmpty(aluno.Nome))
            //    ModelState.AddModelError("Nome", "Nome é obrigatório");

            //if (string.IsNullOrEmpty(aluno.Sexo))
            //    ModelState.AddModelError("Sexo", "Sexo é obrigatório");

            //if (string.IsNullOrEmpty(aluno.Email))
            //    ModelState.AddModelError("Email é obrigatório", "Email é obrigatório");

            //if (aluno.Nascimento <= DateTime.Now.AddYears(-18))
            //    ModelState.AddModelError("Nascimento", "Data de nascimento inválida");

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                AlunoBll _aluno = new AlunoBll();
                _aluno.IncluirAluno(aluno);
                return RedirectToAction("Index");
            }

        }

        public IActionResult CreateMotos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMotos(Moto moto)
        {
            if (string.IsNullOrEmpty(moto.Nome))
                ModelState.AddModelError("Nome", "Nome é obrigatório");

            if (string.IsNullOrEmpty(moto.Cor))
                ModelState.AddModelError("Cor", "Cor é obrigatório");

            if (moto.Cilindrada <= 0)
                ModelState.AddModelError("Cilindrada", "Insira a Cilindrada");

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                MotoBll _moto = new MotoBll();
                _moto.IncluirMoto(moto);

                return RedirectToAction("Privacy");
            }
        }

        public IActionResult Privacy()
        {
            MotoBll _moto = new MotoBll();
            List<Moto> motos = _moto.GetMotos().ToList();


            return View("ListaMotos", motos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
