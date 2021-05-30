namespace UniversitySystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Faculties;
    using UniversitySystem.Models.Faculties.BindingModels;
    using UniversitySystem.Models.JoiningModels;
    using UniversitySystem.Models.Studies;
    using UniversitySystem.Services.Interfaces;

    public class FacultiesController : Controller
    {
        private readonly IFacultiesService facultiesService;
        private readonly IStudiesService studiesService;
        private readonly IFacultyStudiesService facultyStudiesService;

        public FacultiesController(IFacultiesService facultiesService, IStudiesService studiesService, IFacultyStudiesService facultyStudiesService)
        {
            this.facultiesService = facultiesService;
            this.studiesService = studiesService;
            this.facultyStudiesService = facultyStudiesService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<FacultyModel> faculties = this.facultiesService.GetAll();



            return View(faculties);
        }


        [HttpGet]
        public IActionResult AddStudiesToFaculty()
        {
            IEnumerable<FacultyModel> faculties = facultiesService.GetAll();
            IEnumerable<StudieModel> studies = studiesService.GetAll();


            ViewBag.Studies = studies;
            ViewBag.Faculties = faculties;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudiesToFaculty(FacultyStudies model)
        {

            IEnumerable<FacultyModel> faculties = facultiesService.GetAll();
            IEnumerable<StudieModel> studies = studiesService.GetAll();


            ViewBag.Studies = studies;
            ViewBag.Faculties = faculties;

            await this.facultyStudiesService.CreateAsync(model);

            return this.RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Details(string id)
        {
            List<FacultyStudies> joiningTable = this.facultyStudiesService.GetAllById(id);
            List<StudieModel> studiesInFaculty = new List<StudieModel>();
            FacultyViewModel faculty = this.facultiesService.GetForViewById(id);
            foreach (var item in joiningTable)
            {
                studiesInFaculty.Add(studiesService.GetById(item.StudieId));
            }
            ViewBag.Studies = studiesInFaculty;

            bool isfacultyNull = faculty == null;
            if (isfacultyNull)
            {

                return this.RedirectToAction("index");

            }

            return this.View(faculty);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FacultyBindingModel model)
        {

            FacultyModel facultyFromDb = this.facultiesService.GetByName(model.Name);

            bool isFacultyAlreadyInDb = facultyFromDb != null;

            if (isFacultyAlreadyInDb)
            {
                return this.RedirectToAction("Index");
            }

            await this.facultiesService.CreateAsync(model);

            return this.RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            FacultyModel faculty = this.facultiesService.GetById(id);

            bool isFacultyNull = faculty == null;

            if (isFacultyNull)
            {

                return this.RedirectToAction("Index");

            }

            return this.View(faculty);

        }
        [HttpPost]
        public async Task<IActionResult> Update(FacultyUpdateBindingModel model)
        {

            await this.facultiesService.UpdateAsync(model);

            return this.RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await this.facultiesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }

    }
}
