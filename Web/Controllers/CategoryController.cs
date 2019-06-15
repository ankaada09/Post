using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using Aplication.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGetCategory _getCategory;
        private readonly IEditCategoryCommand _editCategory;
        private readonly IDeleteCategoryCommand _deleteCategory;
        private readonly IGetOneCategory _oneCategory;

        public CategoryController(IGetCategory getCategory, IEditCategoryCommand editCategory, IDeleteCategoryCommand deleteCategory, IGetOneCategory oneCategory)
        {
            _getCategory = getCategory;
            _editCategory = editCategory;
            _deleteCategory = deleteCategory;
            _oneCategory = oneCategory;
        }



        // GET: Category
        public IActionResult Index([FromQuery]CategorySearch search)
        {
            var vm = new CategoryIndexViewModel();
            vm.CategoryPosts = _getCategory.Execute(search);
           
            return View(vm);

        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var dto = _oneCategory.Execute(id);
                return View(dto);
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryPostDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                _editCategory.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNoFound)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExists)
            {
                TempData["error"] = "Kategorija sa istim imenom vec postoji.";
                return View(dto);
            }
        }

        // GET: Category/Delete/5
        public IActionResult  Delete(int id)
        {
            try
            {
                _deleteCategory.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }

        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
    }
}