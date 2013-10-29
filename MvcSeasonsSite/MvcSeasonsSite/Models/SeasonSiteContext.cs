using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace MvcSeasonsSite.Models
{
    public class SeasonSiteContext :DbContext
    {
        public SeasonSiteContext()
            : base("SeasonDBCon")
        {
            Database.SetInitializer(new SeasonSiteInitializer());
            
        }
       
        public DbSet<Special> Specials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
 
        
    }

   
}