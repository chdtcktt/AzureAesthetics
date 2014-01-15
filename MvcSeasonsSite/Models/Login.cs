using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcSeasonsSite.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Oops! You forgot to put yo user ID thingy in")]
        public string User { get; set; }

        [Required(ErrorMessage = "Well this is embarrassing, you did not put in a password")]
        public string Pass { get; set; }

    }
}