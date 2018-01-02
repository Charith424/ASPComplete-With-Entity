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
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime ReleaseDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime AddedDate { get; set; }
        public byte Stock { get; set; }
        public Generes Genere { get; set; }
        public byte GenereId { get; set; }

    }

    public class Generes {
        public byte Id { get; set; }
        public string Genre { get; set; }



    }
}