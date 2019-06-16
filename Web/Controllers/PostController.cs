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
        private readonly IGetAddPost _addPost;

        public PostController(IGetPostsCommand getPost, IGetCategory getCategory, IDeletePost deletePost, PostContext context, IGetOnePostCommand getOne, IEditPostCommand editPost, IGetAddPost addPost)
        {
            _getPost = getPost;
            _getCategory = getCategory;
            _deletePost = deletePost;
            _context = context;
            _getOne = getOne;
            _editPost = editPost;
            _addPost = addPost;
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
        public IActionResult Details(int id)
        {
            try
            {
                ViewBag.Pictures = _context.Pictures.Where(p=> p.PostId== id).Select(o => new PictureDto
                {
                    Name=o.Name
                });

                ViewBag.Comments = _context.Comments.Where(p=> p.PostId == id).Select(p => new CommentDto
                {
                    Comment=p.Comments
                });

                var mi = _getOne.Execute(id);

                
                return View(mi);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            ViewBag.CategoryPosts = _context.CategoryPosts.Select(s => new CategoryPostDto
            {  Id=s.Id,
               Name=s.NameCat

            });

            ViewBag.Users = _context.Users.Select(s => new UserDto
            {
                Id=s.Id,
                UserName=s.Username
            });
            return View();
        }

        //public class AddPost
        //{
        //    public int Id { get; set; }
        //    public IFormFile Image { get; set; }

        //    public string Name { get; set; }
        //    public string Text { get; set; }
        //    public int CategoryId { get; set; }
        //    public int UserId { get; set; }



        //}

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddPostcs p)
        {
            var ext = Path.GetExtension(p.Image.FileName); 
            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }
            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);
                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                var post = new InsertPostDto
                {
                    Name = p.Name,
                    FileName = newFileName,
                    Text = p.Text,
                    CategoryId = p.CategoryId,
                    UserId = p.UserId,

                };
                _addPost.Execute(post);


                return  RedirectToAction("Index");
            }
            catch (EntityNoFound n)
            {
                return NotFound();
            }
            catch (EntityAlreadyExists b) {
                return NotFound();
            }
            catch (Exception e)
            {
                TempData["greska"] = "Doslo je do greske.";

            }
            return View();
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