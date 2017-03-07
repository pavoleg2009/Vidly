using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int NumberInStock { get; set; }
    }
}