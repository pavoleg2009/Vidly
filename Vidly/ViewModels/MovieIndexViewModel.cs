using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieIndexViewModel
    {   
        //public int ItemsOnPage { get; set; }
        //public int PageNum { get; set; }
        public List<Movie> Movies { get; set; }
    }
}