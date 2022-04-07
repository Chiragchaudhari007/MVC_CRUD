using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.ComponentModel.DataAnnotations;





namespace MVC.Models{

    public class Subject {

        [Key]
        public int SubjectId {get; set;}

        [Required]

        public string SubjectName {get; set;}

        [Required]
        public string Syllabus {get; set;}

        [Range(1,5)]

        public int Credits {get; set;}

    

    }
}