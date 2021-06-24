using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.VeiwModels.Movie.Session
{
    public class IndexOfSessionForAdmin
    {
        public string SeasonId { get; set; }
        public byte SeasonNumber { get; set; }
        public string MovieId { get; set; }
        public bool Show { get; set; }
    }
    public class CreateSessionForAdmin
    {
        public byte SeasonNumber { get; set; }
        public string MovieId { get; set; }
    }
    public class EditSessionForAdmin
    {
        public string SeasonId { get; set; }
        public byte SeasonNumber { get; set; }
        public string MovieId { get; set; }
        public bool Show { get; set; }
    }

}
