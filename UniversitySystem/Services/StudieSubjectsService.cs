namespace UniversitySystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniversitySystem.Data;
    using UniversitySystem.Models.JoiningModels;
    using UniversitySystem.Services.Interfaces;

    public class StudieSubjectsService : IStudieSubjectsService
    {
        private readonly ApplicationDbContext dbContext;

        public StudieSubjectsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<StudieSubjects> GetAll()
        {
            IEnumerable<StudieSubjects> joiningSubjects = dbContext.StudieSubjects
                .Select(subject => new StudieSubjects
                {
                    StudieId = subject.StudieId,
                    SubjectId = subject.SubjectId,
                })
                .OrderBy(subject => subject.StudieId)
                .ToList();

            return joiningSubjects;
        }

        public StudieSubjects GetById(string id)
        {
            StudieSubjects studie = this.dbContext.StudieSubjects
                .Where(subject => subject.StudieId == id)
                .SingleOrDefault();

            return studie;
        }
    }
}
