using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.NewFolder.Subjects;
using UniversityCompetition.Models.Students;
using UniversityCompetition.Models.University;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        int nextIdSubject;
        int nextIdUniversity;
        int nextStudentId;

        //new exam
        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }
        public string AddStudent(string firstName, string lastName)
        {
            var fullName = firstName + " " + lastName;    
            if(students.FindByName(fullName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedStudent,firstName, lastName);
            }

            var student = new Student(nextStudentId += 1, firstName, lastName);
            students.AddModel(student); 

            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, "StudentRepository");
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(EconomicalSubject) && subjectType != nameof(HumanitySubject) && subjectType != nameof(TechnicalSubject))
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            ISubject subject = subjects.FindByName(subjectName);
            if (subject != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject newSubject = null;
            if (subjectType == nameof(EconomicalSubject))
            {
                newSubject = new EconomicalSubject(nextIdSubject += 1, subjectName);
            }
            else if (subjectType == nameof(HumanitySubject))
            {
                newSubject = new HumanitySubject(nextIdSubject += 1, subjectName);
            }
            else if (subjectType == nameof(TechnicalSubject))
            {
                newSubject = new TechnicalSubject(nextIdSubject += 1, subjectName);
            }

            subjects.AddModel(newSubject);

            return String.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = universities.FindByName(universityName);
            if (university != null)
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> requiredSubjectsIds = new List<int>();
            //List<int> requiredSubjects = subjects.Models.Select(x => x.Id).ToList();

            foreach (var item in requiredSubjects)
            {
                int neededId = 0;
                if (subjects.Models.Any(s => s.Name == item))
                {
                    var name = subjects.Models.FirstOrDefault(s => s.Name == item);
                    neededId = name.Id;
                    requiredSubjectsIds.Add(neededId);
                }
                
            }

            var newUniveristy = new University(nextIdUniversity += 1, universityName, category, capacity, requiredSubjectsIds);
            universities.AddModel(university);

            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);    
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            var student = students.FindByName(studentName);

            if (student == null)
            {
                return String.Format(OutputMessages.StudentNotRegitered, student.FirstName, student.LastName);
            }

            var university = universities.FindByName(universityName);
            if (university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            var coveredExamsByStudent = student.CoveredExams;
            var universityRequiredSubjects = university.RequiredSubjects;

            if (coveredExamsByStudent != universityRequiredSubjects)
            {
                return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University.Name == universityName)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, universityName);
            }

            student.JoinUniversity(university);

            return String.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            var student = students.FindById(studentId);
            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }

            var subject = subjects.FindById(subjectId);
            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            var university = universities.FindById(universityId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            var studentsCount = students.Models.Count(s => s.University == university);
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsCount}");

            return sb.ToString().TrimEnd();
        }
    }
}
