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
    public class UsersController : Controller
    {
        private readonly UserService _userservice;

        public UsersController(UserService userservice)
        {
            _userservice = userservice;
        }
        // GET: UsersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO userDTO)
        {
           
            try
            {
                UserDTO user = _userservice.Register(userDTO);
                if (user!=null)
                {
                    TempData["token"] = user.jwtToken;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.Error = "Not Registered";
            return View();
        }

        // GET: UsersController/Edit/5
        public ActionResult Login(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserDTO userDTO)
        {
            try
            {
                UserDTO user = _userservice.Login(userDTO);
                if (user != null)
                {
                    TempData["token"] = user.jwtToken;
                    return RedirectToAction("Index", "Pizza");
                }
            }
            catch
            {
                return View();
            }
            ViewBag.Error = "Not Registered";
            return View();
        }
        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
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
