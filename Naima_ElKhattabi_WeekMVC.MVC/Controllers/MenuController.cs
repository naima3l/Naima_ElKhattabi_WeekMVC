using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Naima_ElKhattabi_WeekMVC.Core.BusinessLayer;
using Naima_ElKhattabi_WeekMVC.MVC.Helper;
using Naima_ElKhattabi_WeekMVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naima_ElKhattabi_WeekMVC.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;

        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }

        public IActionResult Index()
        {
            var menus = BL.GetMenus();

            List<MenuViewModel> menusViewModel = new List<MenuViewModel>();

            foreach (var item in menus)
            {
                menusViewModel.Add(item.toMenuViewModel());
            }
            return View(menusViewModel);
        }

        public IActionResult Details(int id)
        {
            var menu = BL.GetMenus().FirstOrDefault(m => m.Id == id);
            var menuViewModel = menu.toMenuViewModel();

            return View(menuViewModel);
        }

        //add
        [Authorize(Policy = "Rest")] 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "Rest")]
        [HttpPost]
        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                BL.AddNewMenu(menuViewModel.toMenu());
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }

        //Edit

        [Authorize(Policy = "Rest")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var menu = BL.GetMenus().FirstOrDefault(m => m.Id == id);
            var menuViewModel = menu.toMenuViewModel();
            return View(menuViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "Rest")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Edit(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                BL.EditMenu(menuViewModel.toMenu());
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }

        //DELETE

        [Authorize(Policy = "Rest")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Delete(int id)
        {
            var menu = BL.GetMenus().FirstOrDefault(m => m.Id == id);
            var menuViewModel = menu.toMenuViewModel();
            return View(menuViewModel);
        }

        [HttpPost]
        [Authorize(Policy = "Rest")] //non solo chiede il login/autenticazione ma richiede che il ruolo sia Administrator
        public IActionResult Delete(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                BL.DeleteMenu(menuViewModel.toMenu().Id);
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }
    }
}
