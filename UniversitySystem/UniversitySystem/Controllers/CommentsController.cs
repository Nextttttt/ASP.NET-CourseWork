namespace UniversitySystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Comunication.Comments;
    using UniversitySystem.Models.Comunication.Comments.BindingModels;
    using UniversitySystem.Services.Interfaces;

    public class CommentsController : Controller
    {

        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<CommentModel> comments = this.commentsService.GetAll();



            return View(comments);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            CommentViewModel comment = this.commentsService.GetForViewById(id);

            bool isSubjectNull = comment == null;
            if (isSubjectNull)
            {

                return this.RedirectToAction("index");

            }

            return this.View(comment);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommentBindingModel model)
        {

            await this.commentsService.CreateAsync(model);

            return this.RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            CommentModel comment = this.commentsService.GetById(id);

            bool isCommentNull = comment == null;

            if (isCommentNull)
            {

                return this.RedirectToAction("Index");

            }

            return this.View(comment);

        }
        [HttpPost]
        public async Task<IActionResult> Update(CommentUpdateBindingModel model)
        {

            await this.commentsService.UpdateAsync(model);

            return this.RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await this.commentsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }

    }
}
