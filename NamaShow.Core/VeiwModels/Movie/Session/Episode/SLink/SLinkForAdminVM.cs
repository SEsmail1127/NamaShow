using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.Movie.Session.Episode.SLink
{
  public  class IndexSLinkForAdmin
    {
        public string LinkId { get; set; }
        [Required(ErrorMessage = "please upload movies file")]
        public string LinkName { get; set; }
        public string EpisodeId { get; set; }
        public int? Price { get; set; }
        public bool Show { get; set; }

    }
  public  class EditSLinkForAdmin
    {
        public string LinkId { get; set; }
        [Required(ErrorMessage = "please upload movies file")]
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public string EpisodeId { get; set; }
        public int? Price { get; set; }
        public bool Show { get; set; }

    }
  public  class CreateSLinkForAdmin
    {
        [Required(ErrorMessage = "please upload movies file")]
        public string LinkName { get; set; }
        public string EpisodeId { get; set; }
        public int? Price { get; set; } 
        public string LinkUrl { get; set; }

    }

}
