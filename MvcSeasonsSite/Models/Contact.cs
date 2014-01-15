using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSeasonsSite.Models
{
    public class Contact
    {
          
        public int Id { get; set; }

        [Required(ErrorMessage = "Opps! You forgot to enter an email address")]
        [RegularExpression(".+\\@.+\\..+",
        ErrorMessage = "Aww Man! It has to be a valid email address.")]
        public string Email { get; set; }

       
        public DateTime CreatedDate { get; set; }
       
    }
}