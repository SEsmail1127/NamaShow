using Microsoft.AspNetCore.Http;
using NamaShow.DataLayer.Entities.Movie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.MovieForAdminVM
{
    public class CreateMovieByAdmin
    {

        [Display(Name = "Movie Title")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 50, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Title { get; set; }

        [Display(Name = "Movie Describe")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 1000, ErrorMessage = "{0} cant longer than {1} character ")]
        [DataType(DataType.MultilineText)]
        public string Describe { get; set; }

        [Display(Name = "Actore")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Actors { get; set; }

        [Display(Name = "Movie Director")]
        [MaxLength(length: 50, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Director { get; set; }
        [Display(Name = "Movie Picture")]
        public IFormFile MoviePicture { get; set; }
        public IFormFile Trailer { get; set; }

        [EnumDataType(typeof(MovieType))]
        public MovieType MovieType { get; set; }
        public bool Show { get; set; }
        [DataType(DataType.Date)]
        public DateTime? releaseTime { get; set; }
        [DataType(DataType.Date)] 
        public DateTime? EndTime { get; set; }
        public string country { get; set; }
        public string ParentId { get; set; }
    }
    public class EditMovieByAdmin
    {
        public string MovieId { get; set; }
        [Display(Name = "Movie Title")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 50, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Title { get; set; }

        [Display(Name = "Movie Describe")]
        [Required(ErrorMessage = "please fill your {0}")]
        [MaxLength(length: 500, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Describe { get; set; }

        [Display(Name = "Actore")]
        [MaxLength(length: 100, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Actors { get; set; }

        [Display(Name = "Movie Director")]
        [MaxLength(length: 50, ErrorMessage = "{0} cant longer than {1} character ")]
        public string Director { get; set; }
        [Display(Name = "Movie Picture")]
        public IFormFile MoviePicture { get; set; }
        public IFormFile Trailer { get; set; }
        [EnumDataType(typeof(MovieType))]
        public MovieType MovieType { get; set; }
        public float? Imdb { get; set; }
        public bool Show { get; set; }
        public DateTime? releaseTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string country { get; set; }
     public List<CatMovie> CatMovies { get; set; }
    }
    public class IndexMovieForAdmin
    {
        public string Title { get; set; }
        public string MoviePicture { get; set; }
        public DateTime? releaseTime { get; set; }
      //  public float? Imdb { get; set; }
        public MovieType MovieType { get; set; }
        public string MovieId { get; set; }
        public bool Show { get; set; }
      
    }
    public class ListOfMovieForSlide
    {
        public string MovieId { get; set; }
        public string Title { get; set; }
    }

}
