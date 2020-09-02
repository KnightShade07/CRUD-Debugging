using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithIssuesCore.Models
{
    public class Student
    {
        //Normally, I would get rid of this since it's not being used,
        //but I don't feel comfortable potentially breaking something
        //after all this hard work. It's not affecting anything, so I'll
        //leave it be.
        public Student()
        {

        }
        /// <summary>
        /// The student's ID.
        /// </summary>
        [Key]
        public int StudentId { get; set; }

        /// <summary>
        /// The student's name.
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// The student's date of birth
        /// </summary>
        
        //To get rid of the DateTime and just have
        //this as a date, cast it as a Date
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
