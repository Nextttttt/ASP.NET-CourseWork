namespace UniversitySystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Subjects;
    using UniversitySystem.Models.Subjects.BindingModels;
    using UniversitySystem.Services.Interfaces;

    public class SubjectsController : Controller
    {

        private readonly ISubjectsService subjectsService;

        public SubjectsController(ISubjectsService subjectsService)
        {
            this.subjectsService = subjectsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<SubjectModel> subjects = this.subjectsService.GetAll();



            return View(subjects);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            SubjectViewModel subject = this.subjectsService.GetForViewById(id);

            bool isSubjectNull = subject == null;
            if(isSubjectNull)
            {

                return this.RedirectToAction("index");

            }

            return this.View(subject);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubjectBindingModel model)
        {

            SubjectModel subjectFromDb = this.subjectsService.GetByName(model.Name);

            bool isSubjectAlreadyInDb = subjectFromDb != null;

            if(isSubjectAlreadyInDb)
            {
                return this.RedirectToAction("Index");
            }

            await this.subjectsService.CreateAsync(model);

            return this.RedirectToAction("Index");

            
        }
        
        [HttpGet]
        public IActionResult Update(string id)
        {
            SubjectModel subject = this.subjectsService.GetById(id);

            bool isSubjectNull = subject == null;

            if(isSubjectNull)
            {

                return this.RedirectToAction("Index");

            }

            return this.View(subject);

        }
        [HttpPost]
        public async Task<IActionResult> Update(SubjectUpdateBindingModel model)
        {

            await this.subjectsService.UpdateAsync(model);

            return this.RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await this.subjectsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
