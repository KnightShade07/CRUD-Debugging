using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithIssuesCore.Models
{
    public static class StudentDb
    {
        public static Student Add(Student s, SchoolContext context)
        {
            //Add student to context
            context.Students.Add(s);

            //Save the database changes
            context.SaveChanges();
            return s;
        }

        public static List<Student> GetStudents(SchoolContext context)
        {
            return (from s in context.Students
                    select s).ToList();
        }

        public static Student GetStudent(SchoolContext context, int id)
        {
            Student s2 = context
                            .Students
                            .Where(s => s.StudentId == id)
                            .Single();
            return s2;
        }

        public static void Delete(SchoolContext context, Student s)
        {


            //Mark the object as deleted
            context.Entry(s).State = EntityState.Deleted;

            //Save the changes to the databse
            context.SaveChanges();
        }

        public static void Update(SchoolContext context, Student s)
        {
            context.Entry(s).State = EntityState.Modified;
            context.SaveChanges();

            return View();
        }
    }
}
