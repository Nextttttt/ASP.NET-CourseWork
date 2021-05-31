namespace UniversitySystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Comunication.Posts;
    using UniversitySystem.Models.Comunication.Posts.BindingModels;
    using UniversitySystem.Services.Interfaces;

    public class PostsController : Controller
    {

        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<PostModel> posts = this.postsService.GetAll();



            return View(posts);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            PostViewModel post = this.postsService.GetForViewById(id);

            bool isPostNull = post == null;
            if (isPostNull)
            {

                return this.RedirectToAction("index");

            }

            return this.View(post);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostBindingModel model)
        {

            PostModel postFromDb = this.postsService.GetByName(model.Title);

            bool isPostAlreadyInDb = postFromDb != null;

            if (isPostAlreadyInDb)
            {
                return this.RedirectToAction("Index");
            }

            await this.postsService.CreateAsync(model);

            return this.RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            PostModel post = this.postsService.GetById(id);

            bool isPostNull = post == null;

            if (isPostNull)
            {

                return this.RedirectToAction("Index");

            }

            return this.View(post);

        }
        [HttpPost]
        public async Task<IActionResult> Update(PostUpdateBindingModel model)
        {

            await this.postsService.UpdateAsync(model);

            return this.RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await this.postsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
