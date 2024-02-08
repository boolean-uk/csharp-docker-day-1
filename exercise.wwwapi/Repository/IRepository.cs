﻿using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {

        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int studentId);
        Task<Student> UpdateStudent(int studentId, string firstName, string lastName, string dateOfBirth, List<int> courseIds);
        Task<Student> CreateStudent(string firstName, string lastName, string dateOfBirth, List<int> courseIds);
        Task<bool?> DeleteStudent(int studentId);
        




        /*====================================================================================================*/



        Task<IEnumerable<Course>> GetCourses();
        Task<Course?> GetCourse(int courseId);
        Task<Course?> UpdateCourse(int courseId, string courseTitle, string courseStartDate, int averageGrade);
        Task<Course> CreateCourse(string courseTitle, string courseStartDate, int averageGrade);
        Task<bool?> DeleteCourse(int courseId);
    }

}
