using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Naima_ElKhattabi_WeekMVC.Core.BusinessLayer;
using Naima_ElKhattabi_WeekMVC.MVC.Helper;
using Naima_ElKhattabi_WeekMVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.MVC.Controllers
{
    public class DishController : Controller
    {
        private readonly IBusinessLayer BL;

        public DishController(IBusinessLayer bl)
        {
            BL = bl;
        }

        public IActionResult Index()
        {
            var dishes = BL.GetDishes();

            List<DishViewModel> dishesViewModel = new List<DishViewModel>();

            foreach (var item in dishes)
            {
                dishesViewModel.Add(item.toDishViewModel());
            }
            return View(dishesViewModel);
        }

        public IActionResult Details(int id)
        {
            var dish = BL.GetDishes().FirstOrDefault(d => d.Id == id);
            var dishViewModel = dish.toDishViewModel();

            return View(dishViewModel);
        }

        //add
        [Authorize(Policy = "Cust")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "Cust")]
        [HttpPost]
        public IActionResult Create(DishViewModel dishViewModel)
        {
            if (ModelState.IsValid)
            {
                BL.AddNewDish(dishViewModel.toDish());
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(dishViewModel);
        }

        //Edit

        [Authorize(Policy = "Cust")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dish = BL.GetDishes().FirstOrDefault(d => d.Id == id);
            var dishViewModel = dish.toDishViewModel();

            return View(dishViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "Cust")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Edit(DishViewModel dishViewModel)
        {
            if (ModelState.IsValid)
            {
                BL.EditDish(dishViewModel.toDish());
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(dishViewModel);
        }

        //DELETE

        [Authorize(Policy = "Cust")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Delete(int id)
        {
            var dish = BL.GetDishes().FirstOrDefault(d => d.Id == id);
            var dishViewModel = dish.toDishViewModel();

            return View(dishViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "Cust")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Delete(DishViewModel dishViewModel)
        {
            if (ModelState.IsValid)
            {
                BL.DeleteDish(dishViewModel.toDish().Id);
                return RedirectToAction(nameof(Index));
            }
            LoadViewBag();
            return View(dishViewModel);
        }


        private void LoadViewBag()
        {
            ViewBag.Tipologia = new SelectList(new[]{
                new { Value="1", Text="Primo"},
                new { Value="2", Text="Secondo"},
                new { Value="3", Text="Contorno"},
                new { Value="4", Text="Dolce"} }.OrderBy(x => x.Text), "Value", "Text");
        }
    }
}
