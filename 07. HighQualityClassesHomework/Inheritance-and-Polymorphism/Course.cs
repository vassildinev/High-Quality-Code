namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;

    public class Course
    {
        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
        }

        public Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get;
            set;
        }

        public string TeacherName
        {
            get;
            set;
        }

        public IList<string> Students
        {
            get;
            set;
        }
    }
}
