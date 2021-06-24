using System.ComponentModel.DataAnnotations;

namespace NamaShow.DataLayer.Entities
{
    public class UserRole
    {
        [Key]
        public int UR_Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        #region Relation
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        #endregion
    }
}
