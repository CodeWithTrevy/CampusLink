using System;

namespace CampusLinkApp.Models
{
    public class Student : Person
    {
        public string StudentID { get; private set; }

        public Student(string name, string gender, int age, string studentID)
            : base(name, gender, age)
        {
            StudentID = studentID;
        }

        // setting the student ID 
        public void SetStudentID(string id)
        {
            if (string.IsNullOrEmpty(StudentID))
                StudentID = id;
        }
    }
}

