using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.Movie.Session.Episode
{
  public class CreateEpisodeForAdmin
    {
        [Required]
        public byte EpisodeNumber { get; set; }
        public DateTime PuttingUpDate { get; set; }
        public string SeasonId { get; set; }

    }

   public class EditEpisodeForAdmin
    {
        public string EpisodeId { get; set; }
        [Required]
        public byte EpisodeNumber { get; set; }
        public string SeasonId { get; set; }
        public bool Show { get; set; }
    }
 public class IndexEpisodeForAdmin
    {
        public string EpisodeId { get; set; }
        [Required]
        public byte EpisodeNumber { get; set; }
        public string SeasonId { get; set; }
        public bool Show { get; set; }

    }
}
