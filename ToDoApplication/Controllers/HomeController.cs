using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DB.ToDo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoApplication.Models;
using ToDoApplication.DataMapper;
namespace ToDoApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToDoRepository _toDoReposiotry;

        public HomeController(ILogger<HomeController> logger, IToDoRepository toDoRepository)
        {
            _logger = logger;
            _toDoReposiotry = toDoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _toDoReposiotry.GetAll();
            return View(items?.uiToDoItems());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ToDoItem());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoItem uiItem)
        {
            try
            {
                await _toDoReposiotry.Create(uiItem.dbToDoItem());
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogError($"{nameof(HomeController)}.{nameof(Create)}", ex);
                // redirect to Error View/Method etc
            }
            // add item in db
            // return back to list
            return View(new ToDoItem());
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var item = await _toDoReposiotry.Get(id);
            return View("Create", item?.uiToDoItem());
        }

        [HttpPost]
        public async Task<IActionResult> Update(ToDoItem uiItem)
        {
            try
            {
                await _toDoReposiotry.Update(uiItem.dbToDoItem());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(HomeController)}.{nameof(Update)}", ex);
                // redirect to Error View/Method etc
                return RedirectToAction(nameof(Index));

            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _toDoReposiotry.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(HomeController)}.{nameof(Delete)}", ex);
                // redirect to Error View/Method etc
                return RedirectToAction(nameof(Index));

            }

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
