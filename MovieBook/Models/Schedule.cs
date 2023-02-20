using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieBook.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }
        [Required]
        public string Movie { get; set; }
        [Required]
        public string Cinema { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        [Range(0, 1000)]
        public int BookPrice { get; set; }
    }
}