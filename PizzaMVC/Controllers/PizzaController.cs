using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaMVC.Models;
using PizzaMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzaService _pizzaservice;

        public PizzaController(PizzaService pizzaService)
        {
            _pizzaservice = pizzaService;
        }
        // GET: PizzaController
        public IActionResult Index()
        {
            List<PizzaDTO> pizzas = null;
            if (TempData["token"] != null)
            {
                try
                {
                    pizzas = (List < PizzaDTO > )_pizzaservice.AllPizzas(TempData.Peek("token").ToString());
                }
                catch (Exception)
                {
                    return View();
                }
            }
            return View(pizzas);
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
