﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models.NewFolder.Subjects
{
    public class EconomicalSubject : Subject
    {
        public EconomicalSubject(int subjectId, string subjectName)
            : base(subjectId, subjectName, 1.0)
        {
        }
    }
}
