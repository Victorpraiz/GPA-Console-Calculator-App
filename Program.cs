using ConsoleTables;
using GPA_Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

//Declaring variables
string studentName;
int numberOfCourses;
string courseCode;
int courseUnit;
int courseScore;
char grade;
int gradeUnit;
int weightPoint;
string remark;
List<StudentCourses> studentResult = new List<StudentCourses>();
int totalCourseUnitRegistered = 0;
int totalCourseUnitPassed = 0;
int totalWeightPoint = 0;
float gpa;

//getting user inputs
Console.Write("\nWhat is Your Name?: ");
studentName = Console.ReadLine();

Console.Clear();
Console.WriteLine($"\nDear {studentName}, Welcome to Your GPA Calculator App\n\n" +
    $"How Many Courses Do You Want To Calculate?");

numberOfCourses = Int32.Parse(Console.ReadLine());

Console.Clear();


//Logic for grades and remarks
for (int i = 0; i < numberOfCourses; i++)
{
    Console.WriteLine($"\n****************** COURSE {i + 1} **********************"); 

    Console.Write("\nWhat is The Course Code?: ");
    courseCode = Console.ReadLine();

    Console.Write("\nWhat is The Course Unit?: ");
    courseUnit = Int32.Parse(Console.ReadLine());

    Console.Write($"\nWhat Did You Score In {courseCode}?: ");
    courseScore = Int32.Parse(Console.ReadLine());

    if (courseScore >= 70)
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

    else { grade = 'F'; gradeUnit = 0; weightPoint = 0; remark = "Fail"; }


    //result calculations
    totalCourseUnitRegistered += courseUnit;
    if (courseScore >= 40)
    {
        totalCourseUnitPassed += courseUnit;
    }
    totalWeightPoint += weightPoint;


    //pushing user input or object to list
    StudentCourses studentCourses = new StudentCourses(courseCode, courseUnit, courseScore, grade,gradeUnit, weightPoint, remark);
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



