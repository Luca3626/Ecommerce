using AppEcommerce.Models;
using AppEcommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppEcommerce.Controllers
{
    public class AutenticaController : Controller
    {
        private readonly IAutenticaRepository _autenticaRepository;

        public AutenticaController(IAutenticaRepository autenticaRepository)
        {
            _autenticaRepository = autenticaRepository;



        }
        // visualizza la pagina di login
        public IActionResult Login()
        {
            return View();
        }
        // visualizza la pagina di registrazione
        public IActionResult Registra()
        {
            return View();
        }
        // action che salva il cliente nel database (serializza la stringa json
        // contenuta nella risposta) e invia una risposta al client con il codice 200
        [HttpPost]
        public IActionResult SaveUser([FromBody] Cliente cliente ) {
          _autenticaRepository.SaveClient(cliente);
              return Ok();
        }

        [HttpPost]
        //acton che esegue il login
        public IActionResult LoginUser([FromBody] Cliente cliente)
        {
           Cliente c= _autenticaRepository.GetClient(cliente.Username,cliente.Password);
            if (c != null)
            {
                HttpContext.Session.SetString("username",c.Username);
                return Ok();    
            }
            else
             return NotFound();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            //HttpContext.Session.Clear(); cancella la sessione
            return RedirectToAction("Index", "Home");
            
        }

    }
}
