using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterfliesHunter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ButterfliesHunter.Controllers
{
    [Authorize]
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

        public IActionResult Details(int? id)
        {
            return View(_hunterRepository.GetHunter(id??1));
        }

        [HttpPost]
        public IActionResult Create([Bind("HunterId,Name,Email,Voted,Display")] Hunter hunter)
        {

            return View(hunter);
        }
    }
}