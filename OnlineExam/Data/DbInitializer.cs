using OnlineExam.Context;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Data
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            using (var context = new DatabaseContext())
            {
                if (context.Professors.Any())
                {
                    return; // Has professor
                }

                var department = new Department();

                if (context.Departments.Any())
                {
                    department = context.Departments.First();
                }
                else
                {
                    department.DepartmentName = "Department";
                }

                context.Add(department);
                context.SaveChanges();

                var course = new Course();

                if (context.Courses.Any())
                {
                    course = context.Courses.First();
                }
                else
                {
                    course.CourseName = "Course";
                    course.Department = department;
                }

                context.Add(course);
                context.SaveChanges();

                var professor = new Professor() { FirstName = "test", LastName = "test", Email = "test@test.com", Password = "test", ProfessorId = "prof1234", Role = Enums.Role.Admin, Course = course, Department = department };

                context.Add(professor);
                context.SaveChanges();
            }
        }
    }
}
