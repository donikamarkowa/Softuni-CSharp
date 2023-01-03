using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private readonly List<IStudent> students;

        public StudentRepository()
        {
            this.students = new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models => this.students;

        public void AddModel(IStudent model)
        {
            students.Add(model);    
        }

        public IStudent FindById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public IStudent FindByName(string name)
        {
            var fullName = name.Split();
            var firstName = fullName[0];
            var lastName = fullName[1];

            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName) ;
        }
    }
}
