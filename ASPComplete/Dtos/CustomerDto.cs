using ASPComplete.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPComplete.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]       
        public string Name { get; set; }

        public bool IsSubsceibedToNewsLetter { get; set; }        
        [Required]
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
                                           //   [Min18Validation]
        public DateTime? BirthDate { get; set; }

    }
} 