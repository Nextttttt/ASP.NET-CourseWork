using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models.Studies;
using UniversitySystem.Models.Studies.BindingModels;
using UniversitySystem.Models.Faculties;
using UniversitySystem.Models.Faculties.BindingModels;
namespace UniversitySystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using UniversitySystem.Models.Subjects.BindingModels;
    using UniversitySystem.Models.Subjects;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using UniversitySystem.Models;
    using UniversitySystem.Models.Comunication.Comments;
    using UniversitySystem.Models.Comunication.Posts;
    using UniversitySystem.Models.Studies;
    using UniversitySystem.Models.Faculties;
    using UniversitySystem.Models.JoiningModels;

    public class ApplicationDbContext : IdentityDbContext<UniversityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SubjectModel> Subjects { get; set; }

        public DbSet<StudieModel> Studies { get; set; }

        public DbSet<StudieSubjects> StudieSubjects { get; set; }

        public DbSet<PostModel> Posts { get; set; }

        public DbSet<CommentModel> Comments { get; set; }

        public DbSet<FacultyModel> Faculties { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            
        }
        public DbSet<UniversitySystem.Models.Subjects.BindingModels.SubjectBindingModel> SubjectBindingModel { get; set; }
        public DbSet<UniversitySystem.Models.Subjects.BindingModels.SubjectUpdateBindingModel> SubjectUpdateBindingModel { get; set; }
        public DbSet<UniversitySystem.Models.Subjects.SubjectViewModel> SubjectViewModel { get; set; }
        public DbSet<UniversitySystem.Models.Studies.StudieViewModel> StudieViewModel { get; set; }
        public DbSet<UniversitySystem.Models.Studies.BindingModels.StudieBindingModel> StudieBindingModel { get; set; }
        public DbSet<UniversitySystem.Models.Studies.BindingModels.StudieUpdateBindingModel> StudieUpdateBindingModel { get; set; }
        public DbSet<UniversitySystem.Models.Faculties.FacultyViewModel> FacultyViewModel { get; set; }
        public DbSet<UniversitySystem.Models.Faculties.BindingModels.FacultyBindingModel> FacultyBindingModel { get; set; }
        public DbSet<UniversitySystem.Models.Faculties.BindingModels.FacultyUpdateBindingModel> FacultyUpdateBindingModel { get; set; }


       
    }
}
