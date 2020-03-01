using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSenior.Models;
using MSenior.Protos;
using Newtonsoft.Json;

namespace MSenior.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            string name = (string)TempData["Key"];
            if (name != null)
            {
                var channel = GrpcChannel.ForAddress("https://localhost:5001");

                var greeterClient = new Greeter.GreeterClient(channel);

                var reply = await greeterClient.MoviesDataAsync(
                                  new MovieRequest { Name = name });

                ViewBag.movies = JsonConvert.DeserializeObject<List<Movies>>(reply.Movies);
                ViewBag.dataResults = JsonConvert.DeserializeObject<DataResult>(reply.DataResult);

                return View();
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Search(string label)
        {
            TempData["Key"] = label;
            return RedirectToAction("Index","Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
