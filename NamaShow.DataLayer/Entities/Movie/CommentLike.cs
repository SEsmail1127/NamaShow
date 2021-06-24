namespace NamaShow.DataLayer.Entities.Movie
{
    public class CommentLike
    {
        public int CommentLikeId { get; set; }
        public bool IsLike { get; set; }
        public string UserIP { get; set; }
        public int CommentId { get; set; }
      
        #region Relation
        public virtual Comment Comment { get; set; }
        #endregion
    }


}
