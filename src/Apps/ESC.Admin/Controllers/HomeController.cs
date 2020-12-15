using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ESC.Admin.Models;
using ESC.Admin.Repositories.Interfaces;
using ESC.Admin.ViewModels;

namespace ESC.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConstituencyRepository _constituencyRepository;

        public HomeController(ILogger<HomeController> logger,
                              IConstituencyRepository constituencyRepository)
        {
            _logger = logger;
            _constituencyRepository = constituencyRepository ?? throw new ArgumentNullException(nameof(IConstituencyRepository));
        }

        public async Task<IActionResult> Index()
        {
            var constituencies = await _constituencyRepository.GetConstituencies();
            var registedVotersCount = constituencies.Sum(p => p.ElectoralPopulation);
            var model = new DashboardViewModel
            {
                RegisteredVotersCount = registedVotersCount,
                Constituencies = constituencies
            };

            return View(model);
        }

        public IActionResult Voter()
        {
            return View();
        }

        public IActionResult Nomination()
        {
            return View();
        }

        public IActionResult Party()
        {
            return View();
        }

        public IActionResult Candidate()
        {
            return View();
        }

        public IActionResult Election()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
