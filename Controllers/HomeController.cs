using AllariTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AllariTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRickAndMortyApiService _apiService;

        public HomeController(IRickAndMortyApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<ActionResult> Index()
        {
            var characters = await _apiService.GetCharactersAsync();
            return View(characters);
        }

        [HttpGet]
        public async Task<ActionResult> GetData()
        {
            var characters = await _apiService.GetCharactersAsync();
            return PartialView("~/Views/Home/Character/_CharacterTable.cshtml", characters);
        }
    }
}