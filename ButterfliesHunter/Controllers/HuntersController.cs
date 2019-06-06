using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterfliesHunter.Models;
using Microsoft.AspNetCore.Mvc;

namespace ButterfliesHunter.Controllers
{
    public class HuntersController : Controller
    {
        private readonly IHunterRepository _hunterRepository;

        public HuntersController(IHunterRepository hunterRepository)
        {
            _hunterRepository = hunterRepository;
        }

        public IActionResult Index()
        {
            var hunters = _hunterRepository.GetHunters();
            return View(hunters);
        }
    }
}