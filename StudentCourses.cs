using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA_Calculator
{
    public class StudentCourses
    {
        public string CourseCode { get; set; }
        public int CourseUnit { get; set; }
        public int CourseScore { get; set; }
        public char Grade { get; set; }
        public int GradeUnit { get; set; }
        public int WeightPoint { get; set; }
        public string Remark { get; set; }

        public StudentCourses(string courseCode, int courseUnit, int courseScore, char grade,
            int gradeUnit, int weightPoint, string remark )
        {
            CourseCode = courseCode;
            CourseUnit = courseUnit;
            CourseScore = courseScore;
            Grade = grade;
            GradeUnit = gradeUnit;
            WeightPoint = weightPoint;
            Remark = remark;
        }
    }
}
