using GS_DevTest.General.Model;
using GS_DevTest.General.Util;
using GS_DevTest.Models;
using GS_DevTest.Service.Interface;
using GS_DevTest.Service.Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GS_DevTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IVillagerManager IVillagerManager;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            this.IVillagerManager = new VillagerManager(config);
        }

        [HttpPost]
        public IActionResult GetCountOfDeath(string age,string year)
        {
            var getdata = KillsCalculationLogic.CountOfDeath(Convert.ToInt32(age), Convert.ToInt32(year));
            return Json(getdata);
        }



        public IActionResult Index()
        {

            var model = new ListVillageViewModel();
            model.VillageList = IVillagerManager.GetAllData();
            model.average = IVillagerManager.GetAverageKills().average != null ? IVillagerManager.GetAverageKills().average.Value:0;
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(VillagerModel model)
        {
            try
            {
                IVillagerManager.Create(model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VillagerModel model)
        {
            try
            {

                // TODO: Add update logic here
                IVillagerManager.Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public IActionResult Edit(int Id)
        {
            var model = IVillagerManager.GetDataById(Id);
            return View(model);
        }


        public IActionResult Delete(int Id)
        {
            var model = IVillagerManager.GetDataById(Id);
            return View(model);
        }


        [HttpPost]
        public IActionResult Delete(VillagerModel model)
        {


            IVillagerManager.Delete(model.Id);


            return RedirectToAction("Index");
        }

    }
}
