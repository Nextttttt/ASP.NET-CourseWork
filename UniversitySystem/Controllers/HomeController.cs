namespace UniversitySystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Comunication.Posts;
    using UniversitySystem.Services.Interfaces;

    public class HomeController : Controller
    {
        private readonly IPostsService postsService;

        public HomeController(IPostsService postsService)
        {
            this.postsService = postsService;
        }
        public IActionResult Index()
        {
            IEnumerable<PostModel> posts = this.postsService.GetAll();

            return View(posts);
        }

        public IActionResult AddNew()
        {
            return this.View();
        }
    }
}
