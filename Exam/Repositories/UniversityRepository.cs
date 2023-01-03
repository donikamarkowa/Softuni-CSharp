using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private readonly List<IUniversity> universities;

        public UniversityRepository()
        {
            this.universities = new List<IUniversity>();
        }
        public IReadOnlyCollection<IUniversity> Models => this.universities;

        public void AddModel(IUniversity model)
        {
            universities.Add(model);    
        }

        public IUniversity FindById(int id)
        {
            return universities.FirstOrDefault(u => u.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return universities.FirstOrDefault(u => u.Name == name);
        }
    }
}
