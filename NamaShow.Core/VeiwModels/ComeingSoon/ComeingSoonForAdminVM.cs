using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.ComeingSoonVM
{
    public class CreateComeingSoon
    {
        [Required]
        public string MovieId { get; set; }
        [Required]
        public string Url { get; set; }
        public bool Show { get; set; }
    }
    public class EditComeingSoon
    {
        [Required]
        public string ComeingSoonId { get; set; }
        [Required]
        public string MovieId { get; set; }
        [Required]
        public string Url { get; set; }
        public bool Show { get; set; }
    }
    public class IndexComeingSoon
    {
        [Required]
        public string ComeingSoonId { get; set; }
        [Required]
        public string MovieId { get; set; }
        public bool Show { get; set; }
        public string Picture { get; set; }
    }


}
