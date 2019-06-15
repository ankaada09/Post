using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.Helpers;
using Aplication.ICommand;
using Aplication.Search;
using DataAcess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Web.Controllers
{
    public class PostController : Controller
    {

        private readonly IGetPostsCommand _getPost;
        private readonly IGetCategory _getCategory;
        private readonly IDeletePost _deletePost;
        private readonly PostContext _context;
        private readonly IGetOnePostCommand _getOne;
        private readonly IEditPostCommand _editPost;
        

        public PostController(IGetPostsCommand getPost, IGetCategory getCategory, IDeletePost deletePost, PostContext context, IGetOnePostCommand getOne, IEditPostCommand editPost)
        {
            _getPost = getPost;
            _getCategory = getCategory;
            _deletePost = deletePost;
            _context = context;
            _getOne = getOne;
            _editPost = editPost;
        }














        // GET: Post
        public IActionResult Index([FromQuery]PostSearch search)
        {
            var vm = new PostIndexViewModel();
            vm.Posts = _getPost.Execute(search);
            vm.CategoryPosts = _getCategory.Execute(new Aplication.Search.CategorySearch
            {
                OnlyActive = true
            });
            return View(vm);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            ViewBag.CategoryPosts = _context.CategoryPosts.Select(s => new CategoryPostDto
            {  Id=s.Id,
               Name=s.NameCat

            });
            return View();
        }

        // POST: Post/Create
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

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Pictures = _context.Pictures.Select(p => new PictureDto
            {
                Id = p.Id,
                Name = p.Name

            });

            //var dto = _getOne.Execute(id);
            //return View(dto);
            return View();


        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            var ext = Path.GetExtension(p.Image.FileName); //.gif
            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }

            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);
                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                var post = new UpdatePostDto
                {
                    Name = p.Name,
                    //Pictures = newFileName,
                    Text = p.Text
                };
                _editPost.Execute(post);

                return RedirectToAction(nameof(Index));
            }
            catch (EntityNoFound)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExists)
            {
                TempData["error"] = "Kategorija sa istim imenom vec postoji.";
                return View(p);
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _deletePost.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return RedirectToAction("index");
            }
        }

        // POST: Post/Delete/5
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
        public  class Post{

            public int Id { get; set; }
            public IFormFile Image { get; set; }

            public string Name { get; set; }
            public string Text { get; set; }
          

        }
      
    }
}