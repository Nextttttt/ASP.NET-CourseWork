namespace UniversitySystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Models.Faculties;
    using UniversitySystem.Models.Faculties.BindingModels;
    using UniversitySystem.Services.Interfaces;

    public class FacultiesController : Controller
    {
        private readonly IFacultiesService facultiesService;

        public FacultiesController(IFacultiesService facultiesService)
        {
            this.facultiesService = facultiesService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<FacultyModel> faculties = this.facultiesService.GetAll();



            return View(faculties);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            FacultyViewModel faculty = this.facultiesService.GetForViewById(id);

            bool isFacultyNull = faculty == null;
            if (isFacultyNull)
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
