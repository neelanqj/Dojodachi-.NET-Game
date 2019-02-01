using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("Pet") == null) {
                ResetSessionPet();
            } 

            Pet myPet = JsonConvert.DeserializeObject<Pet>(HttpContext.Session.GetString("Pet"));
            return View(myPet);
        }

        public void ResetSessionPet() {
            HttpContext.Session.SetString("Pet", JsonConvert.SerializeObject(new Pet()));
        }

        [HttpPost]
        public IActionResult Index(String action) {
            Pet model;

            if(action=="reset") {
                ResetSessionPet();
               
            }
            model = GetSessionPet();
            
            if(model.State == "Loose" || model.State == "Win") {
                return View(model);
            }

            if (action=="feed")
                model.Feed();
            else if(action=="play")
                model.Play();
            else if(action == "sleep")
                model.Sleep();
            else if(action =="work")
                model.Work();

            UpdateSessionPet(model);

            return View(model);
        }

        public void UpdateSessionPet(Pet myPet){
            HttpContext.Session.SetString("Pet", JsonConvert.SerializeObject(myPet));
            return;
        }
        public Pet GetSessionPet(){
            Pet myPet = JsonConvert.DeserializeObject<Pet>(HttpContext.Session.GetString("Pet"));
            return myPet;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
