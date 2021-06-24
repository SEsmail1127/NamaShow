using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamaShow.DataLayer.Entities.Movie
{
    public class Episode
    {
        [Key]
        public int EpisodeId { get; set; }
        [Required]
        public byte EpisodeNumber { get; set; }
        public DateTime PuttingUpDate { get; set; }
        public int? SeasonId { get; set; }
        public bool IsDelete { get; set; }
        public bool Show { get; set; }


        #region Relation
        public virtual List<Link> Links { get; set; }
        public virtual Season Season { get; set; }
        #endregion

    }

}
