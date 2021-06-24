using NamaShow.DataLayer.Entities.Movie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.DataLayer.Entities
{
  public  class Payment
    {
        public int PaymentId { get; set; }
        public bool IsPay { get; set; }
        public int UserId { get; set; }
        public int LinkId { get; set; }
        public DateTime PayDate { get; set; }
      
        public int Amount { get; set; }

        #region Relation
        public virtual User User { get; set; } 

        [ForeignKey("Amount")]
        public virtual Link Link { get; set; }
        #endregion
    }
}
