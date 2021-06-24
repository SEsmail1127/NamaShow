namespace NamaShow.DataLayer.Entities.Movie
{
    public class CatMovie
    {
        public int CatMovieId { get; set; }
        public int CategorieId { get; set; }
        public int MovieId { get; set; }
     

        #region Relation
        public virtual NamaShow.DataLayer.Entities.Categorie.Categorie Categorie { get; set; }
        public virtual Movie Movie { get; set; }
        #endregion

    }
}
