namespace UniversitySystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Data;
    using UniversitySystem.Models.JoiningModels;
    using UniversitySystem.Services.Interfaces;
    public class FacultyStudiesService : IFacultyStudiesService
    {
        private readonly ApplicationDbContext dbContext;

        public FacultyStudiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public FacultyStudies GetById(string Facultyid, string StudieId)
        {
            FacultyStudies facultyStudie = this.dbContext.FacultyStudies
               .Where(s => s.FacultyId == Facultyid && s.StudieId == StudieId)
               .SingleOrDefault();

            return facultyStudie;
        }

        public async Task CreateAsync(FacultyStudies model)
        {
            FacultyStudies facultyStudies = new FacultyStudies
            {
                StudieId = model.StudieId,
                FacultyId = model.FacultyId
            };

            await this.dbContext.FacultyStudies.AddAsync(facultyStudies);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string Studieid, string Subjectid)
        {
            FacultyStudies facultyStudies = this.GetById(Studieid, Subjectid);

            bool isNull = facultyStudies == null;

            if (isNull)
            {
                return;
            }

            this.dbContext.Remove(facultyStudies);
            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<FacultyStudies> GetAll()
        {
            IEnumerable<FacultyStudies> joiningSubjects = dbContext.FacultyStudies
                .Select(studie => new FacultyStudies
                {
                    StudieId = studie.StudieId,
                    FacultyId = studie.FacultyId,
                })
                .OrderBy(subject => subject.FacultyId)
                .ToList();

            return joiningSubjects;
        }

        public List<FacultyStudies> GetAllById(string id)
        {
            List<FacultyStudies> faculties = this.dbContext.FacultyStudies
                .Where(faculty => faculty.StudieId == id)
                .ToList();

            return faculties;
        }

        public async Task DeleteAsync(string id)
        {
            List<FacultyStudies> faculties = this.dbContext.FacultyStudies
                .Where(s => s.StudieId == id)
                .ToList();

            bool isStudieNull = faculties == null;

            if (isStudieNull)
            {
                return;
            }
            foreach (var item in faculties)
            {
                this.dbContext.Remove(item);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}