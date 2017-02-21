using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "My cuntom error message for Movie Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReleaseDate { get; set; }

        public List<Genre> Genres { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        public string Title => Id!= 0 ? "Edit Movie" : "New Movie";

        //public string Title
        //{
        //    get { return Id != 0 ? "Edit Movie" : "New Movie"; }
        //}

        public NewMovieViewModel()
        {
            Id = 0;
        }
        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}