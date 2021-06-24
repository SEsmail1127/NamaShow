using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamaShow.DataLayer.Entities.Movie
{
    public class Link
    {
        public int LinkId { get; set; }
        [Required(ErrorMessage ="please upload movies file")]
        public string LinkUrl { get; set; }
        public string LinkName { get; set; }
        public int? EpisodeId { get; set; }
        public int? Price { get; set; }
        public bool Show { get; set; }
        public bool IsDelete { get; set; }


        #region Relation      
        public virtual Episode Episode { get; set; }
        #endregion
    }


}
