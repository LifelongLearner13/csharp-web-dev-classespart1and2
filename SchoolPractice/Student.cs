using System;
namespace SchoolPractice
{
    public class Student
    {
        private static int nextStudentId = 1;
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int NumberOfCredits { get; set; }
        public double Gpa { get; set; }

        public Student(string name, int studentId,
            int numberOfCredits, double gpa)
        {
            Name = name;
            StudentId = studentId;
            NumberOfCredits = numberOfCredits;
            Gpa = gpa;
        }

        public Student(string name, int studentId)
        : this(name, studentId, 0, 0) { }

        public Student(string name)
        : this(name, nextStudentId)
        {
            nextStudentId++;
        }

        public void AddGrade(int courseCredits, double grade)
        {
            // Update the appropriate properties: NumberOfCredits, Gpa
            double totalQualityScore = Gpa * NumberOfCredits;
            totalQualityScore += courseCredits * grade;
            NumberOfCredits += courseCredits;
            Gpa = totalQualityScore / NumberOfCredits;
        }

        public string GetGradeLevel(int credits)
        {
            /*
             * Freshman (0-29 credits), Sophomore (30-59 credits)
             * Junior (60-89 credits), Senior (90+ credits)
             */
            if(credits <= 29)
            {
                return "Freshman";
            }

            if(credits <= 59)
            {
                return "Sophomore";
            }

            if(credits <= 89)
            {
                return "Junior";
            }
            
            return "Senior";
        }

        public override string ToString()
        {
            return Name + " (Credits: " + NumberOfCredits + ", GPA: " + Gpa + ")";
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            Student studentObj = obj as Student;
            return StudentId == studentObj.StudentId;
        }

        public override int GetHashCode()
        {
            return StudentId;
        }


    }
}
