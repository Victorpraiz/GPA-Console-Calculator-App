using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace GPA_Calculator
{
    public class PrintTable
    {
       public static void StudentResult(List<StudentCourses> studentResult)
        {
            var table = new ConsoleTable("COURSE & CODE", "COURSE UNIT", "GRADE", "GRADE UNIT", "WEIGHT Pt.", "REMARK");

            foreach (StudentCourses course in studentResult)
            {
                table.AddRow(course.CourseCode, course.CourseUnit, course.Grade, course.GradeUnit, course.WeightPoint, course.Remark);
            }

            Console.WriteLine(table);

        }
    }
}
