namespace UniversitySystem.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.JoiningModels;
    using UniversitySystem.Models.Studies;
    using UniversitySystem.Models.Studies.BindingModels;
    using UniversitySystem.Models.Subjects;
    using UniversitySystem.Services.Interfaces;

    public class StudiesController : Controller
    {
        private readonly IStudiesService studiesService;
        private readonly ISubjectsService subjectsService;

        public StudiesController(IStudiesService studiesService, ISubjectsService subjectsService)
        {

            this.studiesService = studiesService;
            this.subjectsService = subjectsService;

        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<StudieModel> studies = studiesService.GetAll();

            return View(studies);
        }


        public IActionResult AddSubjectsToStudie()
        {
            IEnumerable<SubjectModel> subjects = subjectsService.GetAll();
            IEnumerable<StudieModel> studies = studiesService.GetAll();


            ViewBag.Studies = studies;
            ViewBag.Subjects = subjects;

            return View();
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            StudieSubjects joiningTable = this.
            StudieViewModel studie = this.studiesService.GetForViewById(id);

            bool isStudieNull = studie == null;
            if (isStudieNull)
            {

                return this.RedirectToAction("index");

            }

            return this.View(studie);

        }
       
        [HttpGet]
        public IActionResult Create()
        {
            

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudieBindingModel model)
        {

            StudieModel studie = studiesService.GetByName(model.Name);

            bool isStudieAlreadyInDb = studie != null;

            if(isStudieAlreadyInDb)
            {

                return this.RedirectToAction("Index");

            }

            await studiesService.CreateAsync(model);

            return this.RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            StudieModel studie = studiesService.GetById(id);

            bool isStudieNull = studie == null;

            if (isStudieNull)
            {

                return this.RedirectToAction("Index");

            }

            return this.View(studie);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StudieUpdateBindingModel model)
        {

            await this.studiesService.UpdateAsync(model);

            return this.RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await this.studiesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
