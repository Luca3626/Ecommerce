using AppEcommerce.Models;
using AppEcommerce.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppEcommerce.Controllers
{
    public class OrdiniController : Controller
    {
        private readonly IProdottoRepository _prodottoRepository;
        private readonly IAutenticaRepository _autenticaRepository;
        private readonly IOrdineRepository _ordineRepository;
        private Sessione<Carrello> _sessione;
        public OrdiniController(IProdottoRepository prodottoRepository, IAutenticaRepository autenticaRepository, IOrdineRepository ordineRepository)
        {
            _prodottoRepository = prodottoRepository;
            _sessione = new Sessione<Carrello>("carrello");
            _autenticaRepository = autenticaRepository; 
            _ordineRepository = ordineRepository;


        }
        //view che visualiza il checkout
        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("username");
            if(username!=null)
             return View( _autenticaRepository.GetClientByUsername(username));
            else
            return RedirectToAction("Index", "Home");
        }
        //view che salva l'ordine e cancella il carrello dalla sessione
        [HttpPost]
        public IActionResult Checkout([FromBody] Ordine ordine)
        {
            //prende la stringa json già serializzata
            string car_json = _sessione.GetJson(HttpContext.Session);
            ordine.DettagliCarrello = car_json;
            _ordineRepository.SaveOrdine(ordine);
            _sessione.Remove(HttpContext.Session);
            return Ok();
        }

        //view che visualizza il carrello
        public IActionResult Carrello()
        {
            Carrello c = _sessione.Deserializza(HttpContext.Session);
            return View(c);
        }

        // action che aggiunge  un prodotto o se il prodotto esiste modifica la quantità selezionata nel carrello
        public IActionResult AggiornaCarrello(long id_prod)
        {
            Prodotto p = _prodottoRepository.GetProduct(id_prod)!;

            ProdottoSelezionato ps = new()
            {
                IdProdotto = p.IdProdotto,
                Nome = p.Nome,
                Quantita = p.Quantita,
                Prezzo = p.Prezzo,
                Descrizione = p.Descrizione,
                Qs = 1
            };
         
            Carrello c = _sessione.Deserializza(HttpContext.Session);
            c.AddProdotto(ps);
            _sessione.Serializza(c, HttpContext.Session);
            return  RedirectToAction(nameof(Carrello));
        }
      //cancella dal carrello il prodotto selezionato o svuota il carrello
        public IActionResult Delete(long id)
        {
            Carrello c = _sessione.Deserializza(HttpContext.Session);
            if (id!=0)
                c.ClearProduct(id);
            else
                c.ClearCarrello();
            _sessione.Serializza(c, HttpContext.Session);
            return RedirectToAction(nameof(Carrello));

        }
        //action che modifica la quantita selezionata del prodotto nel carrello
        [HttpPost]
         public IActionResult Edit(long id_prodotto,int qs)
        {
            Carrello c = _sessione.Deserializza(HttpContext.Session);
            c.EditProductQs(id_prodotto, qs);
            _sessione.Serializza(c, HttpContext.Session);
            return RedirectToAction(nameof(Carrello)); 
                
         }

        //action che visualizza gli ordini
        public IActionResult DisplayOrders()
        {
            string? username = HttpContext.Session.GetString("username");
            List<DettaglioOrdine> dettagli = _ordineRepository.LoadOrders(username);
            ViewData["ContaOrdini"] = dettagli.Count;
            return View("Ordine", _ordineRepository.LoadOrders(username));
 
        }



    }
}
