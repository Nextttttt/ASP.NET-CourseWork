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

        public StudieSubjects GetById(string Studieid, string Subjectid)
        {
            StudieSubjects studieSubject = this.dbContext.StudieSubjects
               .Where(subject => subject.SubjectId == Subjectid && subject.StudieId == Studieid)
               .SingleOrDefault();

            return studieSubject;
        }

        public async Task CreateAsync(StudieSubjects model)
        {
            StudieSubjects studieSubject = new StudieSubjects
            {
                StudieId = model.StudieId,
                SubjectId = model.SubjectId
            };

            await this.dbContext.StudieSubjects.AddAsync(studieSubject);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string Studieid, string Subjectid)
        {
            StudieSubjects studieSubject = this.GetById(Studieid, Subjectid);

            bool isNull = studieSubject == null;

            if (isNull)
            {
                return;
            }

            this.dbContext.Remove(studieSubject);
            await this.dbContext.SaveChangesAsync();
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

        public List<StudieSubjects> GetAllById(string id)
        {
            List<StudieSubjects> subjects = this.dbContext.StudieSubjects
                .Where(studie => studie.StudieId == id)
                .ToList();

            return subjects;
        }

        public async Task DeleteAsync(string id)
        {
            List<StudieSubjects> studies = this.dbContext.StudieSubjects
                .Where(s => s.StudieId == id)
                .ToList();

            bool isStudieNull = studies == null;

            if (isStudieNull)
            {
                return;
            }
            foreach(var item in studies)
            {
                this.dbContext.Remove(item);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
