namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private string name;
        private IList<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Course name must be a non-empty string");
                }

                this.name = value;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddStudent(Student studentToAdd)
        {
            if (this.students.Count < 30)
            {
                this.students.Add(studentToAdd);
            }
            else
            {
                throw new InvalidOperationException("Course must have less than or equal to 30 students");
            }
        }

        public void RemoveStudent(Student studentToRemove)
        {
            if (this.students.Count > 0)
            {
                this.students.Remove(studentToRemove);
            }
            else
            {
                throw new InvalidOperationException("Course students list is empty, cannot remove non-existing student");
            }
        }
    }
}
