using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSeasonsSite.Models
{
    public class Special
    {
        public int Id { get; set; }


        [DataType(DataType.MultilineText)]   
        public string Content { get; set; }  

    }
}