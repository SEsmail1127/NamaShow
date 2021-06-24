using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.CategorieForAdmin
{
   public class CreateCategorieForAdmin
    {
        [Required(ErrorMessage = "please fill in title")]
        public string Title { get; set; }
        public int? ParentId { get; set; }
    }
   public class EditCategorieForAdmin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "please fill in title")]
        public string Title { get; set; }
        public int? ParentId { get; set; }
    }
    public class IndexCategorieForAdmin
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
    }
}
