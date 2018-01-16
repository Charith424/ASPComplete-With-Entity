using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPComplete.Models
{
    public class NewMovie
    {
        public Movie Movie { get; set; }
        public IEnumerable<Generes> Generes { get; set; }
    }
}