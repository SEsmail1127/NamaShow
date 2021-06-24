using NamaShow.DataLayer.Entities.Categorie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NamaShow.DataLayer.Entities.Movie
{
    public  class Movie
    {
        [Key]
        public int MovieId { get; set; }
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
        public string MoviePicture { get; set; }
        public string Trailer { get; set; }
        public MovieType MovieType { get; set; }
        public float? Imdb { get; set; }
        public int? Time { get; set; }
        public bool Show { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? releaseTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string country { get; set; }

        public int? ParentId { get; set; }


        #region relation 
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Rate> Rates { get; set; }        
        public virtual List<CatMovie> CatMovies { get; set; }
        public virtual List< Comment> Comments { get; set; }
        public virtual List<Season> Seasons { get; set; }
        public virtual List<MovieLink>  MovieLinks { get; set; } 
        [ForeignKey("ParentId")]
        public virtual List<Movie> Movies { get; set; }

        #endregion

    }
}
