using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.NewFolder.Subjects
{
    public class TechnicalSubject : Subject
    {
        public TechnicalSubject(int subjectId, string subjectName)
            : base(subjectId, subjectName, 1.3)
        {
        }
    }
}
