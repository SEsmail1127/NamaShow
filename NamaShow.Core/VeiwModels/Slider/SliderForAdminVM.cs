using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.Slider
{
   public class CreateSliderForAdmin
    {    
        public bool Show { get; set; }
        [Required]
        public string Url { get; set; }
        public byte Order { get; set; }
        [Required]
        public string MovieId { get; set; }
    }
    public class EditSliderForAdmin
    {
        [Required]
        public string SlideId { get; set; }
        public bool Show { get; set; }
        [Required]
        public string Url { get; set; }
        public byte Order { get; set; }
        [Required]
        public string MovieId { get; set; }
    }
    public class IndexSliderForAdmin
    {
        public string SlideId { get; set; }
        public bool Show { get; set; }      
        public byte Order { get; set; }
        public string MovieId { get; set; }
        public string Picture { get; set; }
    }
}
