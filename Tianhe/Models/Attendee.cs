using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tianhe.Models
{
    public class Attendee
    {
        public Attendee()
        {
            CreateOn = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public DateTime CreateOn { get; set; }

        [MaxLength(50)]
        public String Ip { get; set; }

        [MaxLength(10)]
        public String Gender { get; set; }

        [MaxLength(50)]
        public String Name { get; set; }

        [MaxLength(20)]
        [Index(IsUnique = true)]
        public String MobiPhoneNumber { get; set; }

        [MaxLength(50)]
        public String Province { get; set; }

        [MaxLength(50)]
        public String City { get; set; }
    }
}