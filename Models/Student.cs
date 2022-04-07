
using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MVC.Models
{

    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]

        public string StudentName { get; set; }

        [Required]

        public string StudentClass { get; set; }

        // [ForeignKey("Subject")]
        // [Display(Name = "Subject")]

        // public int SubjectId { get; set; }

        // public virtual Subject Subject { get; set; }

    }
}