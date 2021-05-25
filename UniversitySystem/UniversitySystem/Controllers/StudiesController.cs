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
        private readonly IStudieSubjectsService studieSubjectsService;

        public StudiesController(IStudiesService studiesService, ISubjectsService subjectsService, IStudieSubjectsService studieSubjectsService)
        {

            this.studiesService = studiesService;
            this.subjectsService = subjectsService;
            this.studieSubjectsService = studieSubjectsService;

        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<StudieModel> studies = studiesService.GetAll();

            return View(studies);
        }

        [HttpGet]
        public IActionResult AddSubjectsToStudie()
        {
            IEnumerable<SubjectModel> subjects = subjectsService.GetAll();
            IEnumerable<StudieModel> studies = studiesService.GetAll();


            ViewBag.Studies = studies;
            ViewBag.Subjects = subjects;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubjectsToStudie(StudieSubjects model)
        {
            IEnumerable<SubjectModel> subjects = subjectsService.GetAll();
            IEnumerable<StudieModel> studies = studiesService.GetAll();


            ViewBag.Studies = studies;
            ViewBag.Subjects = subjects;

           await this.studieSubjectsService.CreateAsync(model);

            return this.RedirectToAction("Index");
          
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            List<StudieSubjects> joiningTable = this.studieSubjectsService.GetAllById(id);
            List<SubjectModel> subjectsInStudie = new List<SubjectModel>();
            StudieViewModel studie = this.studiesService.GetForViewById(id);
            foreach (var item in joiningTable)
            {
                subjectsInStudie.Add(subjectsService.GetById(item.SubjectId));
            }
            ViewBag.Subjects = subjectsInStudie;

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


            StudieModel studieFromDb = this.studiesService.GetByName(model.Name);

            bool isStudieAlreadyInDb = studieFromDb != null;

            if (isStudieAlreadyInDb)
            {
                return this.RedirectToAction("Index");
            }

            await this.studiesService.CreateAsync(model);

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
            await this.studieSubjectsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
