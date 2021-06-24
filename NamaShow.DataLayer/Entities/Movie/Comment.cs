using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NamaShow.DataLayer.Entities.Movie
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required(ErrorMessage ="please fill your comment text")]
        public string CommentText { get; set; }

        [Required(ErrorMessage ="please fill your Email")]
        public string Email { get; set; }  

        [Required(ErrorMessage ="please fill your Name")]
        public string Name { get; set; }
        public bool Readed { get; set; }
        public bool Show { get; set; }
        public int MovieId { get; set; }

        #region Relation
        public virtual List<CommentLike> CommentLikes { get; set; }
        public virtual Movie Movie { get; set; }
        #endregion
    }


}
