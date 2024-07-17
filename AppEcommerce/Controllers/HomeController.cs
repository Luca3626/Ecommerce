using AppEcommerce.Models;
using AppEcommerce.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace AppEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdottoRepository _prodottoRepository;

        public HomeController(IProdottoRepository prodottoRepository)
        {
            _prodottoRepository = prodottoRepository;
        }

        //carica la view dei prodotti
        public IActionResult Index()
        {  
            var lista = _prodottoRepository.GetProducts();
            return View(lista);
        }

   
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
