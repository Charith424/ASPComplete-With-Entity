using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPComplete.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubsceibedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? BirthDate { get; set; }
    }
    public class MembershipType
    {

        public byte Id { get; set; }
        public short SingUpFee { get; set; }
        public short DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

        [Required]
        public string Name { get; set; }
    }
}