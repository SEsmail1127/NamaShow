namespace NamaShow.DataLayer.Entities.Movie
{
    public class Rate
    {
        public int RateId { get; set; }
        public int Graid { get; set; }
        public int MovieId { get; set; }
        public string UserIP { get; set; }

        #region Relation
        public virtual Movie Movie { get; set; }
        #endregion

    }


}
