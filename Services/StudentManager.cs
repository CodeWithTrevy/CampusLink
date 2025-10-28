using System;
using System.Collections.Generic;
using System.Linq;
using CampusLinkApp.Interfaces;
using CampusLinkApp.Models;

namespace CampusLinkApp.Services
{
    public class StudentManager : IManageStudents<Student>
    {
        private readonly List<Student> students = new List<Student>();
        private int idCounter = 1;

        public void Add(Student student)
        {
            student.SetStudentID($"S{idCounter:D3}");
            idCounter++;
            students.Add(student);
            Console.WriteLine($"Student {student.Name} added with ID {student.StudentID}.\n");
        }

        public void Edit(Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.StudentID == updatedStudent.StudentID);
            if (student == null)
            {
                Console.WriteLine("Student not found.\n");
                return;
            }

            student.Name = updatedStudent.Name;
            student.Gender = updatedStudent.Gender;
            student.Age = updatedStudent.Age;

            Console.WriteLine("Student details updated successfully.\n");
        }

        public void Delete(string id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);
            if (student == null)
            {
                Console.WriteLine("Student not found.\n");
                return;
            }

            students.Remove(student);
            Console.WriteLine($"Student {id} deleted successfully.\n");
        }

        public List<Student> List()
        {
            // sorting  by Name
            return students.OrderBy(s => s.Name).ToList(); 
        }
    }
}
