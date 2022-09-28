using ConsoleTables;
using GPA_Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

//Declaring variables
string studentName;
int numberOfCourses;
string courseCode;
int courseUnit;
int courseScore;
char grade = ' ';
int gradeUnit = 0;
int weightPoint = 0;
string remark = "";
List<StudentCourses> studentResult = new List<StudentCourses>();
int totalCourseUnitRegistered = 0;
int totalCourseUnitPassed = 0;
int totalWeightPoint = 0;
float gpa;

//getting user inputs
Console.Write("\nWhat is Your Name?: ");
studentName = Console.ReadLine();

Console.WriteLine($"\nDear {studentName}, Welcome to Your GPA Calculator App\n\n");





Point:
Console.WriteLine("How Many Courses Do You Want To Calculate?: ");

while (!int.TryParse(Console.ReadLine(), out numberOfCourses) || numberOfCourses > 5 || numberOfCourses < 1)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("This is not a valid input. number must be between 1-3");
    Console.ForegroundColor = ConsoleColor.White;
    goto Point;

}


Console.Clear();


//Logic for grades and remarks
for (int i = 0; i < numberOfCourses; i++)
{
    Console.WriteLine($"\n****************** COURSE {i + 1} **********************"); 

    Point2:
    Console.Write("\nWhat is The Course Code?: ");
    courseCode = Console.ReadLine();
    var validate = new Regex(@"^[A-Za-z]{1,3}[#]?[0-9]{3}$");
    while (!validate.IsMatch(courseCode))
    {
        Console.Clear();
        Console.WriteLine("Course Code Must Be In This Format ***MAT111***");
        goto Point2;
    }

    Console.Write("\nWhat is The Course Unit?: ");
    courseUnit = Int32.Parse(Console.ReadLine());

    Point3:
    Console.Write($"\nWhat Did You Score In {courseCode}?: ");
    courseScore = Int32.Parse(Console.ReadLine());
    if (courseScore > 100 || courseScore < 0)
    {

        //gradeUnit = 0;

        //remark = "INVALID INPUT";
        Console.WriteLine("Score must be between 0 - 100");
        //Console.WriteLine("Press Enter To Continue");
        //Console.ReadLine();
        goto Point3;
    }

    else if (courseScore >= 70 && courseScore <= 100)
    {
        grade = 'A';
        gradeUnit = 5;
        weightPoint = courseUnit * gradeUnit;
        remark = "Excellent";
    }

    else if (courseScore < 70 && courseScore >= 60)
    {
        grade = 'B';
        gradeUnit = 4;
        weightPoint = courseUnit * gradeUnit;
        remark = "Very Good";
    }

    else if (courseScore < 60 && courseScore >= 50)
    {
        grade = 'C';
        gradeUnit = 3;
        weightPoint = courseUnit * gradeUnit;
        remark = "Good";
    }

    else if (courseScore < 50 && courseScore >= 45)
    {
        grade = 'D';
        gradeUnit = 2;
        weightPoint = courseUnit * gradeUnit;
        remark = "Fair";
    }

    else if (courseScore < 45 && courseScore >= 40)
    {
        grade = 'E';
        gradeUnit = 1;
        weightPoint = courseUnit * gradeUnit;
        remark = "Pass";
    }

    else
    { grade = 'F'; gradeUnit = 0; weightPoint = 0; remark = "Fail"; }

    


    //result calculations
    totalCourseUnitRegistered += courseUnit;
    if (courseScore >= 40)
    {
        totalCourseUnitPassed += courseUnit;
    }
    totalWeightPoint += weightPoint;


    //pushing user input or object to list
    StudentCourses studentCourses = new StudentCourses(courseCode, courseUnit, courseScore, grade, gradeUnit, weightPoint, remark);
    studentResult.Add(studentCourses);

    Console.Clear();
   
}

//printing on the console
gpa = (float)totalWeightPoint/totalCourseUnitRegistered;
Console.WriteLine("***************************** Student Result ******************************\n");

PrintTable.StudentResult(studentResult);

Console.WriteLine("\nTotal Course Unit Registered Is: " + totalCourseUnitRegistered);
Console.WriteLine("\nTotal Course Unit Passed Is: " + totalCourseUnitPassed);
Console.WriteLine("\nTotal Weight Point Is: " + totalWeightPoint);

Console.WriteLine("\nYour GPA is: " + gpa.ToString("f2"));

Console.ReadLine();



