using System.Collections.Generic;

namespace NamaShow.DataLayer.Entities.Movie
{
    public class Season
    {
        public int SeasonId { get; set; }
        public byte SeasonNumber { get; set; }
        public int? MovieId { get; set; }
        public bool IsDelete { get; set; }
        public bool Show { get; set; }

        #region Relation
        public virtual List<Episode> Episodes { get; set; }
        public virtual Movie Movie { get; set; }
        #endregion
    }

}
