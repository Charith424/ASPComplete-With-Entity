using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPComplete.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]

        public DateTime ReleaseDate { get; set; }
        [Required]

        public DateTime AddedDate { get; set; }
        [Required]
        // [MovieStockValidation]
        public byte Stock { get; set; }
     
        [Required]
        public byte GenereId { get; set; }
        public GenereDto Genere { get; set; }
    }
}