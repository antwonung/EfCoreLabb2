using labb2Linq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace labb2Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menu = 1, choice = 0;
            while (menu == 1)
            {
                Console.Clear();
                Console.WriteLine("Hi Welcome to SchoolApp!");
                Console.WriteLine("Enter number of choice :)");
                Console.WriteLine("1 - View all teachers that teaches course: Programmering 1");
                Console.WriteLine("2 - View all students with their teachers");
                Console.WriteLine("3 - View all students who reads programmering 1");
                Console.WriteLine("4 - Edit a subject in courses");
                Console.WriteLine("5 - Update a students teacher");
                Console.WriteLine("6 - End program");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {

                }



                switch (choice)
                {
                    case 1:
                        ViewTeachers();
                        break;

                    case 2:
                        Viewstudents();
                        break;

                    case 3:
                        ViewStudentsProgramming();
                        break;

                    case 4:
                        UpdateSubjectCourse();
                        break;

                    case 5:
                        if (UpdateTeacher())
                        {
                            Console.WriteLine("Change teacher to Reidar in programmering 1");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Change teacher to Anas in programmering 1");
                            Console.ReadLine();
                        }
                        break;
                    case 6:
                        Console.WriteLine("Ending program...");
                        Console.ReadKey();
                        menu = 0;
                        break;

                    default:
                        Console.WriteLine("Wrong input try again..");
                        Console.ReadLine();
                        break;

                }

            }





            //AddUpPeople();


        }
        public static void AddUpPeople()
        {
            using (var context = new PeopleDbContext())
            {
                //var Teacher = new Teacher()
                //{
                //    TeacherName = "Anas",

                //};

                //var Teacher2 = new Teacher()
                //{
                //    TeacherName = "Carola Abbas",

                //};

                //var Grade = new Grade()
                //{
                //    GradeName = "1A",
                //    Section = "Lågstadiet",
                //    TeacherId = 2,
                //};

                //var Grade2 = new Grade()
                //{
                //    GradeName = "4A",
                //    Section = "Mellanstadiet",
                //    TeacherId = 1,
                //};

                //var Student = new Student()
                //{
                //    StudentName = "Karl Pettersson",
                //    GradeName = "1A"
                //};

                //var Student2 = new Student()
                //{
                //    StudentName = "Henke the man",
                //    GradeName = "4A",
                //};

                //var Course = new Course()
                //{
                //    CourseName = "Programmering 2",
                //    CourseStart = new DateTime(2022, 4, 1),
                //    CourseEnd = new DateTime(2022, 5, 31),
                //    TeacherId = 3,

                //};

                //var Course2 = new Course()
                //{
                //    CourseName = "Svenska (4:e klass) - Grammatik",
                //    CourseStart = new DateTime(2022, 3, 1),
                //    CourseEnd = new DateTime(2022, 5, 30),
                //    TeacherId = 2,
                //};


                //var StudentCourse = new StudentCourse()
                //{
                //    StudentId = 2,
                //    CourseName = "Programmering 1",

                //};

                //var StudentCourse2 = new StudentCourse()
                //{
                //    StudentId = 6,
                //    CourseName = "Matematik (1:a klass) - Grundläggande",
                //};


                //context.Entry(Course).State = EntityState.Added;
                /*context.Entry(Course).State = EntityState.Added;*/ //Ändrade dessa efter vilka jag la in.

                //context.SaveChanges();
            }
        }
        public static void ViewStudentsProgramming()
        {
            var course_id = "Programmering 1";
            using (var db = new PeopleDbContext())
            {
                
                var StudentObj = from student in db.Students
                                 from studentCrs in db.StudentCourses
                                 from crs in db.Courses
                                 from tech in db.Teachers
                                 where student.StudentId == studentCrs.StudentId && studentCrs.CourseName == course_id &&
                                 course_id == crs.CourseName && crs.TeacherId == tech.TeacherId
                                 select new
                                 {
                                    StudentName = student.StudentName,
                                    TeacherName = tech.TeacherName,
                                    course = studentCrs.CourseName

                                 };
                                 
                                  
                               
                foreach (var obj in StudentObj)
                {
                    Console.WriteLine($"Student:{obj.StudentName} has teacher: {obj.TeacherName} in course: {obj.course}");
                }

            }
            Console.ReadLine();
        }
        public static bool UpdateTeacher()
        {
            Console.Clear();
            int check = 0;
            using (var db = new PeopleDbContext())
            {

                var teacher = db.Teachers.Where(t => t.TeacherName == "Anas" || t.TeacherName == "Reidar").FirstOrDefault();
                if (teacher.TeacherName == "Anas")
                {
                    teacher.TeacherName = "Reidar";
                    db.SaveChanges();
                    check = 1;
                }
                else if (teacher.TeacherName == "Reidar")
                {
                    teacher.TeacherName = "Anas";
                    db.SaveChanges();
                    check = 2;
                }
            }
            if(check == 1)
            {
                return true;
            }
            else
                return false;
        }
        public static void UpdateSubjectCourse()
        {
            Console.Clear();
            int teachId = 0;
            DateTime start, end;
            string input = "", newSubject = "";
        
            using (var db = new PeopleDbContext())
            {
                var CourseObj = from course in db.Courses
                                select new
                                {
                                    CourseName = course.CourseName,
                                    courseStart = course.CourseStart,
                                    courseEnd = course.CourseEnd, 
                                    TeacherID = course.TeacherId,
                                };
                foreach (var obj in CourseObj)
                {
                    Console.WriteLine($"Course: {obj.CourseName} | teacherId: {obj.TeacherID}");
                }
                Console.Write("Enter course name you want to change:");
                input = Console.ReadLine();
                Console.Write("Enter new course name:");
                newSubject = Console.ReadLine();

                var crs = db.Courses.Where(s => s.CourseName == input).FirstOrDefault();
                if(crs != null)
                {
                    teachId = crs.TeacherId;
                    start = crs.CourseStart;
                    end = crs.CourseEnd;
                    db.Courses.Remove(crs);
                    db.SaveChanges();

                    var Course = new Course()
                    {
                        CourseName = newSubject,
                        CourseStart = start,
                        CourseEnd = end,
                        TeacherId = teachId,

                    };
                    db.Entry(Course).State = EntityState.Added;
                    db.SaveChanges();
                    Console.WriteLine();

                    var CourseObj2 = from course in db.Courses
                                    select new
                                    {
                                        CourseName = course.CourseName,
                                        courseStart = course.CourseStart,
                                        courseEnd = course.CourseEnd,
                                        TeacherID = course.TeacherId,
                                    };
                    foreach (var obj in CourseObj2)
                    {
                        Console.WriteLine($"Course: {obj.CourseName} | teacherId: {obj.TeacherID}");
                    }
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("No match try agaín..");
                    Console.ReadLine();
                }



            }
        }
        public static void Viewstudents()
        {
            using (var db = new PeopleDbContext())
            {
                var StudentObj = from student in db.Students
                                 from teacher in db.Teachers
                                 from grade in db.Grades
                                 where student.GradeName == grade.GradeName && grade.TeacherId == teacher.TeacherId
                                 select new
                                 {
                                     StudentName = student.StudentName,
                                     TeacherName = teacher.TeacherName,
                                 };
                foreach (var obj in StudentObj)
                {
                    Console.WriteLine($"Student:{obj.StudentName} has teacher: {obj.TeacherName}");
                }

            }
            Console.ReadLine();
        }
        public static void ViewTeachers()
        {
            using (var db = new PeopleDbContext())
            {
                var TeacherObj = from course in db.Courses
                                 from teacher in db.Teachers
                                 where course.TeacherId == teacher.TeacherId && course.CourseName == "Programmering 1"
                                 select new
                                 {
                                     name = teacher.TeacherName,
                                     subject = course.CourseName
                                 };
                foreach (var obj in TeacherObj)
                {
                    Console.WriteLine($"Teachers Name:{obj.name} | Course: {obj.subject}");
                }

            }
            Console.ReadLine();
        }


    }
}

