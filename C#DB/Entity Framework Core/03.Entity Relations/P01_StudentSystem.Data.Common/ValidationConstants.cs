﻿
namespace P01_StudentSystem.Data.Common
{
    public static class ValidationConstants
    {
        //Student
        public const int StudentNameMaxLength = 100;
        public const int StudentPhoneNumberMaxLength = 10;

        //Course
        public const int CourseNameMaxLength = 80;

        //Resource
        public const int ResourceNameMaxLength = 50;
        public const int ResourceUrlMaxLength = 2048;

        //Homework
        public const int HomeworkContentMaxLength = 2048;

    }
}
