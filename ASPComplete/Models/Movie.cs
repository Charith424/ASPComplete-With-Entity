using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPComplete.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime AddedDate { get; set; }
        [Required]
        [MovieStockValidation]
        public byte Stock { get; set; }
       
        public Generes Genere { get; set; }
        [Required]
        public byte GenereId { get; set; }

    }

    public class Generes {
        public byte Id { get; set; }
        public string Genre { get; set; }



    }
}