using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithIssuesCore.Models
{
    public static class StudentDb
    {
        /// <summary>
        /// Adds a Student to the Database.
        /// </summary>
        /// <param name="s">The object containing the student data</param>
        /// <param name="context">The object facilitating connection to the Database.</param>
        /// <returns>The object holding the student data.</returns>
        public static Student Add(Student s, SchoolContext context)
        {
            //Add student to context
            context.Students.Add(s);

            //Save the database changes
            context.SaveChanges();
            return s;
        }
        /// <summary>
        /// Gets a list of all the students.
        /// </summary>
        /// <param name="context">The database object</param>
        /// <returns>A list of students</returns>
        public static List<Student> GetStudents(SchoolContext context)
        {
            return (from s in context.Students
                    select s).ToList();
        }

        /// <summary>
        /// Gets a singular student from the Database.
        /// </summary>
        /// <param name="context">Database Object</param>
        /// <param name="id">The ID assigned to the student by the database</param>
        /// <returns></returns>

        public static Student GetStudent(SchoolContext context, int id)
        {
            Student s2 = context
                            .Students
                            .Where(s => s.StudentId == id)
                            .Single();
            return s2;
        }
        /// <summary>
        /// Deletes a Student from the database
        /// </summary>
        /// <param name="context">Database Object</param>
        /// <param name="s">Object containing data.</param>
        public static void Delete(SchoolContext context, Student s)
        {

            //Mark the object as deleted
            context.Entry(s).State = EntityState.Deleted;

            //Save the changes to the database
            context.SaveChanges();
        }
        /// <summary>
        /// Updates a student's data in the database
        /// </summary>
        /// <param name="context">Database object</param>
        /// <param name="s">Student Data</param>
        public static void Update(SchoolContext context, Student s)
        {
            context.Entry(s).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
